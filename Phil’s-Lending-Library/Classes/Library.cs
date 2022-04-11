using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phil_s_Lending_Library
{
    public class Library : ILibrary
    {
        private Dictionary<string, Book> MyDictionary = new Dictionary<string, Book>();
        public int Count => MyDictionary.Count;

        public void Add(string title, string firstName, string lastName, int numberOfPages)
        {
            Book NewBook = new Book(title, firstName, lastName, numberOfPages);
            MyDictionary.TryAdd(title, NewBook);
        }

         public Book Borrow(string title)
         {
             if (MyDictionary.ContainsKey(title))
             {
                //find book 
                Book book = MyDictionary[title];
                //remove book from library
                MyDictionary.Remove(title);
                
                //return book
                return book;
             }
             else return null;
         }
        // Returns an enumerator that iterates through a collection.
        public IEnumerator<Book> GetEnumerator()
        {
            foreach (Book book in MyDictionary.Values)
            {
                yield return book;
            }
        }

        public void Return(Book book)
        {
            MyDictionary.TryAdd(book.Title, book);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
