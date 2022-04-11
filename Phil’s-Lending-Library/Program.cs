using System;
using System.Collections.Generic;

namespace Phil_s_Lending_Library
{
     public class Program
    {
        private static readonly Library library = new Library();
        private static readonly Backpack<Book> TheBackpack = new();

        static void Main(string[] args)
        {
            LoadBooks();
            UserInterface();
        }
        static void LoadBooks()
        {
            library.Add("BEAUTIFUL RUINS", "JESS", "WALTER", 44);
            library.Add("EVERYTHING LEADS TO YOU", "NINA", "LACOUR", 100);
            library.Add("HOLLYWOOD HOMICIDE", "KELLYE", "GARRETT", 250);
        }
        public static void UserInterface()
        {
            Console.WriteLine("Welcome to Phil's Lending Library ...");
            bool continues = true;
            while (continues)
            {
                Console.WriteLine();
                Console.WriteLine(" 1. View all Books");
                Console.WriteLine(" 2. Add a Book");
                Console.WriteLine(" 3. Borrow a Book");
                Console.WriteLine(" 4. Return a Book");
                Console.WriteLine(" 5. View Book Bag");
                Console.WriteLine(" 6. Exit");
                Console.Write("Please choose number from (1-6): ");
                int choose = Convert.ToInt32(Console.ReadLine());
                
                switch (choose)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine();
                        ShowLibrary();
                        Console.WriteLine();
                        Console.WriteLine();

                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine();
                        AddABook();
                        Console.Write("Do you ADD other Book ? (Y/N) ");
                        string ans = Console.ReadLine();
                        while(ans == "y" || ans == "Y")
                        {
                            AddABook();
                            Console.Write("Do you ADD other Book ? (Y/N) ");
                            ans = Console.ReadLine();
                        }
                        ShowLibrary();
                        Console.WriteLine();
                        Console.WriteLine();

                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine();
                        BorrowBook();
                        Console.Write("Do you Borrow other Book ? (Y/N) ");
                        ans = Console.ReadLine();
                        while (ans == "y" || ans == "Y")
                        {
                            BorrowBook();
                            Console.Write("Do you Borrow other Book ? (Y/N) ");
                            ans = Console.ReadLine();
                        }
                        Console.WriteLine();
                        Console.WriteLine();

                        break;
                    case 4:
                        Console.WriteLine();
                        Console.WriteLine();
                        ReturnBook();
                        Console.WriteLine();
                        Console.WriteLine();

                        break;
                    case 5:
                        Console.WriteLine();
                        Console.WriteLine();
                        ViewBookBag();
                        Console.WriteLine();
                        Console.WriteLine();

                        break;
                    case 6:
                        continues = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Options");
                        break;
                }
            }
        }
        static void ShowLibrary()
        {
            Console.WriteLine("   =========================");
            Console.WriteLine("   ===== Library List ======");
            Console.WriteLine("   =========================");
            Console.WriteLine();
            int counter = 1;
            foreach (Book book in library)
            {
                Console.WriteLine($"    {counter++}. {book.Title} BY \"{book.FirstName} {book.LastName}\"");
            }
        }
        static void AddABook()
        {
            Console.WriteLine("   =========================");
            Console.WriteLine("   ======= Book Add ========");
            Console.WriteLine("   =========================");

            Console.WriteLine();
            Console.Write("Book Title: ");
            string title = Console.ReadLine();

            Console.Write("Author First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Author Last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Number of Pages: ");
            int numPages = Convert.ToInt32(Console.ReadLine());
            library.Add(title.ToUpper(), firstName.ToUpper(), lastName.ToUpper(), numPages);
        }
        static void BorrowBook()
        {
            Console.WriteLine("       ================================================");
            Console.WriteLine("       ================ Borrow a Book =================");
            Console.WriteLine("       ================================================");
            Console.WriteLine();
            Console.WriteLine();
            ShowLibrary();
            Console.WriteLine();
            Console.WriteLine("Choose the book you would borrow");
            Console.Write("Enter Book Title: ");
            string selection = Console.ReadLine();

            Book borrowed = library.Borrow(selection.ToUpper());
            TheBackpack.Pack(borrowed);
        }
        static void ReturnBook()
        {
            try
            {
                Console.WriteLine("    =================================");
                Console.WriteLine("    =========== Return Book =========");
                Console.WriteLine("    =================================");
                Console.WriteLine();
                //ViewBookBag();
                Dictionary<int, Book> books = new Dictionary<int, Book>();
                int counter = 0;
                Console.WriteLine( "List of Book Bag ..... ");
                foreach (Book book in TheBackpack)
                {
                    books.Add(counter, book);
                    Console.WriteLine($"{counter + 1}. {book.Title} - {book.FirstName} {book.LastName}");
                    counter++;
                }
                Console.WriteLine();
                Console.Write("Which of your books would you like to return: ");
                string response = Console.ReadLine();
                int.TryParse(response, out int selection);
                if (selection > counter) throw new Exception();
                Book bookToReturn = TheBackpack.Unpack(selection - 1);
                library.Return(bookToReturn);
            }
            catch (Exception)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Out Of Range...");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                ReturnBook();
            }
        }
        static void ViewBookBag()
        {
            Console.WriteLine("   =========================");
            Console.WriteLine("   ======= Book Bag ========");
            Console.WriteLine("   =========================");
            int counter = 0;

            foreach (Book book in TheBackpack)
            {
                Console.WriteLine($"{++counter}. {book.Title}");
            }
            Console.WriteLine($"You have {counter} in your Book Bag");
        }

    }
}
