using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class BinarySerializableBookListStorage : ICustomerStorage<Book>
    {
        string FileName { get; set; }

        public BinarySerializableBookListStorage(string fileName)
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
            BinaryFormatter formatter = new BinaryFormatter();

            if (File.Exists(FileName))
            {
                using (FileStream reader = File.OpenRead(FileName))
                {
                    newListBook = (List<Book>)formatter.Deserialize(reader);
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
        public void Write(List<Book> date)
        {
            if (ReferenceEquals(date, null))throw new ArgumentNullException("date");

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream writer = File.Create(FileName))
            {
                formatter.Serialize(writer, date);
            }
        }
    }
}
