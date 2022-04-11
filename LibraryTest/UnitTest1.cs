using System;
using Xunit;
using Phil_s_Lending_Library;
using System.Collections.Generic;


namespace LibraryTest
{
    public class UnitTest1
    {
        //Add a Book to your Library

        [Fact]
        public void TestAddBookToLibrary()
        {
            Library MyLibrary = new Library();
            MyLibrary.Add("HananStory", "Hanan", "Saadeh", 150);
            MyLibrary.Add("OlaStory", "Ola", "Shlool", 200);
            MyLibrary.Add("NoorStory", "Noor", "Nathem", 100);
            Assert.Equal(3,MyLibrary.Count);
        }
        // Borrowing an existing title returns the Book and remove it
        [Fact]
        public void TestBorrowingExistingTitle()
        {

            Library MyLibrary = new Library();
            MyLibrary.Add("HananStory", "Hanan", "Saadeh", 150);
            MyLibrary.Add("OlaStory", "Ola", "Shlool", 200);
            MyLibrary.Add("NoorStory", "Noor", "Nathem", 100);
            Book BBook= MyLibrary.Borrow("NoorStory");
            //Test the Conter decrease one 
            Assert.Equal(2, MyLibrary.Count);
            //Test The Borrowed book not exist in my library
            Assert.DoesNotContain(BBook, MyLibrary);
        }

        // Borrowing a missing title returns null
        [Fact]
        public void TestBorrowingMissingTitle()
        {
            Library MyLibrary = new Library();
            MyLibrary.Add("HananStory", "Hanan", "Saadeh", 150);
            MyLibrary.Add("OlaStory", "Ola", "Shlool", 200);
            MyLibrary.Add("NoorStory", "Noor", "Nathem", 100);
            Book BBook = MyLibrary.Borrow("EsraaStory");
            Assert.Null(BBook);

        }

        // A returned book is once again in the Library
            [Fact]
          public void TestReturn()
        {
            Library MyLibrary = new Library();
            MyLibrary.Add("HananStory", "Hanan", "Saadeh", 150);
            MyLibrary.Add("OlaStory", "Ola", "Shlool", 200);
            MyLibrary.Add("NoorStory", "Noor", "Nathem", 100);
            Book BBook = MyLibrary.Borrow("NoorStory");
            MyLibrary.Return(BBook);
            Assert.Contains(BBook, MyLibrary);
            Assert.Equal(3, MyLibrary.Count);
        }
        // Pack and Unpack your Backpack
    [Fact]
    public void TestPackUnpack()
        {
            Library MyLibrary = new Library();
            MyLibrary.Add("HananStory", "Hanan", "Saadeh", 150);
            MyLibrary.Add("OlaStory", "Ola", "Shlool", 200);
            MyLibrary.Add("NoorStory", "Noor", "Nathem", 100);
            Book book = MyLibrary.Borrow("NoorStory");
            Backpack<string> items = new Backpack<string>();
            items.Pack(book.Title);
            string title = items.Unpack(0);
            Assert.Equal(title, book.Title);

        }
        [Fact]
        //Test Pack Backpack
        public void TestPackBackpack2()
        {
            Backpack<string> items = new Backpack<string>();
            string Hanan = "Hanan";
            items.Pack(Hanan);

            Assert.Contains(Hanan, items);
        }
            [Fact]
        //Test Unpack Backpack
        public void TestUnpackBackpack()
        {
            Backpack <Book> Items = new Backpack <Book>();
            Book MyBook = new Book("MaryamStory", "Maryam", "Asem", 160);
            Items.Pack(MyBook);
            Items.Unpack(0);
            Assert.DoesNotContain(MyBook, Items);
        }


    }

}





   

