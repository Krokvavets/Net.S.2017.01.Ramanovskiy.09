using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1.CUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            BookListService serves = new BookListService();
            serves.AddBook(new Book("C# 6.0 in a Nutshell, 6th Edition", "Joseph Albahari, Ben Albahari", "computer science", "2015", "O'Reilly Media"));
            serves.AddBook(new Book("C# 6.0 Pocket Reference", "Joseph Albahari, Ben Albahari", "computer science", "2015", "O'Reilly Media"));
            serves.AddBook(new Book("Windows PowerShell for Developers", "Douglas Finke", "computer science", "2012", "O'Reilly Media"));
            serves.AddBook(new Book("Windows PowerShell Cookbook, 3rd Edition", "Lee Holmes", "computer science", "2012", "O'Reilly Media"));
            serves.WriteToFile(new BookListStorage(@"C:\Users\User\Documents\visual studio 2017\Projects\Net.S.2017.01.Ramanovskiy.09\Task1\test.dat"));
            serves.ReadFromFile(new BookListStorage(@"C:\Users\User\Documents\visual studio 2017\Projects\Net.S.2017.01.Ramanovskiy.09\Task1\test.dat"));
            List<Book> list = serves.ListBooks;
            foreach (Book book in list)
            {
                Console.WriteLine(book.ToString());
            }
            Console.ReadKey();
            serves.Sort();
            list = serves.ListBooks;
            foreach (Book book in list)
            {
                Console.WriteLine(book.ToString());
            }
            Console.ReadKey();
            Console.WriteLine(serves.FindBookByTag(x => x.Name.Contains("C# 6.0")));
            Console.ReadKey();
            Console.WriteLine(serves.FindBookByTag(x => x.Year == "2012"));
            Book nbook = null;

            try
            {
                serves.AddBook(nbook);
            }
            catch (Exception ex)
            {
                logger.Info("Empty object of class book");
                logger.Error(ex.StackTrace);
            }

            try
            {
                serves.ReadFromFile(new BookListStorage(@"C:\Users\User\Documents\visual studio 2017\Projects\Net.S.2017.01.Ramanovskiy.09\Task1\teest.dat"));
            }
            catch (Exception ex)
            {
                logger.Info("File not Exists ");
                logger.Error(ex.StackTrace);
            }

           
        }
    }
}
