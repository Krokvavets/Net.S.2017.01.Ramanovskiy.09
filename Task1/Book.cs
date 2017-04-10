using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Book : IFormattable, IComparable, IComparable<Book>
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Year { get; set; }
        public string PublishingHouse { get; set; }

        public Book(string name, string author, string gener, string year, string publishingHouse)
        {
            Name = name;
            Author = author;
            Genre = gener;
            Year = year;
            PublishingHouse = publishingHouse;
        }
        #region ovveride methods
        ///<summary>
        /// Returns a string that represents the current object.
        ///</summary>
        ///<returns>A string that represents the current object.</returns>
        public override string ToString() => this.ToString("G", CultureInfo.CurrentCulture);

        ///<summary>
        /// Serves as the default hash function.
        ///</summary>
        ///<returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return Name.Length ^ PublishingHouse.Length;
        }

        ///<summary>
        /// Determines whether the specified object is equal to the current object.
        ///</summary>
        ///<param name="obj">The object to compare with the current object.</param>
        ///<returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Book)obj);
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (this.Name == other.Name && this.Author == other.Author)
                return true;
            return false;
        }
        #endregion

        public string ToString(string format) => this.ToString(format, CultureInfo.CurrentCulture);
        ///<summary>
        /// Formats the value of the current instance using the specified format.
        ///</summary>
        ///<param name="format">The format to use.</param>
        ///<param name=" provider">The provider to use to format the value.</param>
        ///<returns>The value of the current instance in the specified format.</returns>
        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format)) format = "G";
            if (provider == null) provider = CultureInfo.CurrentCulture;
            CultureInfo cl = (CultureInfo)provider;
            switch (format.ToUpperInvariant())
            {
                case "G":
                case "NAGYP":
                    return String.Format("Book: {0}, Author: {1}  Genre: {2}, Year: {3}, PublishingHouse: {4} ", Name, Author, Genre, Year, PublishingHouse);
                case "N":
                    return String.Format("Book: {0}", Name);
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }
        ///<summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether
        /// the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        ///</summary>
        ///<param name="obj">An object to compare with this instance.</param>
        ///<returns>A value that indicates the relative order of the objects being compared. </returns>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (obj is Book) return CompareTo((Book)obj);
            throw new ArgumentException("Object is not a Book");
        }
        ///<summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether
        /// the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        ///</summary>
        ///<param name="other">An object to compare with this instance.</param>
        ///<returns>A value that indicates the relative order of the objects being compared. </returns>
        public int CompareTo(Book other)
        {
            if (other == null) return 1;
            if (other is Book) return this.Name.CompareTo(other.Name);
            throw new ArgumentException("Object is not a Book");
        }
    }
}
