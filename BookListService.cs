using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class BookListService
    {
        private List<Book> listBooks = new List<Book>();

        public List<Book> ListBooks { get => listBooks.GetRange(0, listBooks.Count); }
        ///<summary>
        /// Adds an object to the end of the Book list.
        ///</summary>
        ///<param name="book">The object to be added to the end of the Book list. The value can be null.</param>
        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException("book is null");
            listBooks.Add(book);
        }
        ///<summary>
        /// Removes the first occurrence of a specific object from the book list.
        ///</summary>
        ///<param name="book">The object to remove from the Book list. The value can be null.</param>
        public void RemoveBook(Book book)
        {
            if (book == null) throw new ArgumentNullException("book is null");
            if (!listBooks.Remove(book)) throw new ArgumentException("The book is not in the list");
        }
        ///<summary>
        ///Searches for an element that matches the conditions defined by the specified predicate,
        ///and returns the first occurrence within the entire book list.
        ///</summary>
        ///<param name="match">The Predicate<Book> delegate that defines the conditions of the element to search for.</param>
        ///<returns>The first element that matches the conditions defined by the specified predicate, if found; otherwise, the default value for type Book.</returns>
        public Book FindBookByTag(Predicate<Book> match) => listBooks.Find(match);
        ///<summary>
        ///Sorts the elements in the entire book list using the specified System.Comparison<Book>.
        ///</summary>
        ///<param name="comparison">The System.Comparison<Book> to use when comparing elements.</param>
        public void SortBooksByTag(Comparison<Book> comparison) => listBooks.Sort(comparison);
        ///<summary>
        ///Sorts the elements in the entire book list using the default comparer.
        ///</summary>
        public void Sort() => listBooks.Sort();
        ///<summary>
        ///Writes a date to the storage
        ///</summary>
        ///<param name="storage">Sets storage.</param>
        public void WriteToFile(ICustomerStorage<Book> storage)
        {
            if (ReferenceEquals(storage,null)) throw new ArgumentNullException("storage is null");
            storage.Write(listBooks);
        }
        ///<summary>
        ///Reads characters from the storage
        ///</summary>
        ///<param name="storage">Sets storage.</param>
        public void ReadFromFile(ICustomerStorage<Book> storage)
        {
            if (ReferenceEquals(storage, null)) throw new ArgumentNullException("storage is null");            
            listBooks =  storage.Read();
        }
    }
}
