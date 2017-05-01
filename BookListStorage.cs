using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class BookListStorage : ICustomerStorage<Book>
    {           
        string FileName { get; set; }

        public BookListStorage(string fileName)
        {
            FileName = fileName;
        }
        ///<summary>
        ///Reads a string from the current stream. The string is prefixed with the length,
        ///encoded as an integer seven bits at a time.
        ///</summary>
        public List<Book> Read()
        {
            List<Book> newListBook = new List<Book>();

            if (File.Exists(FileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        newListBook.Add(new Book(reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString()));
                    }
                }
            }
            else
                throw new FileLoadException("The file not Exists");
            return newListBook;
        }
        ///<summary>
        ///Writes a book list to this stream in the current encoding of the BinaryWriter.
        ///</summary>
        ///<param name="listBooks">The value to write</param>
        public void Write(List<Book> listBooks)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Create)))
            {
                foreach (Book book in listBooks)
                {
                    writer.Write(book.Name);
                    writer.Write(book.Author);
                    writer.Write(book.Genre);
                    writer.Write(book.Year);
                    writer.Write(book.PublishingHouse);
                }
            }
        }
    }
}
