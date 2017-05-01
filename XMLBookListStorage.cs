using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Task1
{
    public class XMLBookListStorage : ICustomerStorage<Book>
    {
        string FileName { get; set; }

        public XMLBookListStorage(string fileName)
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
                using (FileStream reader = File.OpenRead(FileName))
                {
                    XmlReader XMLreader = new XmlTextReader(reader);
                    XMLreader.ReadStartElement();
                    if (XMLreader.IsEmptyElement)
                        return null;

                    while (XMLreader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == Book.xmlName)
                        {
                            XMLreader.ReadStartElement();
                            string name = XMLreader.ReadElementContentAsString("Name", "");
                            string author = XMLreader.ReadElementContentAsString("Author", "");
                            string genre = XMLreader.ReadElementContentAsString("Genre", "");
                            string year = XMLreader.ReadElementContentAsString("Year", "");
                            string publishingHouse = XMLreader.ReadElementContentAsString("PublishingHouse", "");
                            XMLreader.ReadEndElement();
                            newListBook.Add(new Book(name, author, genre, year, publishingHouse));
                        }
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
        public void Write(List<Book> date)
        {
            if (ReferenceEquals(date, null)) throw new ArgumentNullException("date");


            using (FileStream writer = File.Create(FileName))
            {
                XmlWriter XMLwriter = new XmlTextWriter(writer, Encoding.Default);
                foreach (var book in date)
                {
                    XMLwriter.WriteStartElement(Book.xmlName);
                    XMLwriter.WriteElementString("Name", book.Name);
                    XMLwriter.WriteElementString("Author", book.Author);
                    XMLwriter.WriteElementString("Genre", book.Genre);
                    XMLwriter.WriteElementString("Year", book.Year);
                    XMLwriter.WriteElementString("PublishingHouse", book.PublishingHouse);
                    XMLwriter.WriteEndElement();
                }
            }
        }
    }
}
