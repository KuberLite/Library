using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    class Program
    {
        private static BookContext _context;

        static void Main()
        {
            bool flag;
            do
            {
                Console.WriteLine("Welcome to my library!\n########################");  
                flag = true;
                Console.WriteLine("1. Add a book\n2. Get all authors\n3. Get all books\n4. Get all books by author\n5. Delete a book\n6. Exit");
                int listNumber = Int32.Parse(Console.ReadLine());
                switch (listNumber)
                {
                    case 1:
                        Console.Clear();
                        AddBook();
                        break;
                    case 2:
                        Console.Clear();
                        GetAllAuthors();
                        break;
                    case 3:
                        Console.Clear();
                        GetAllBooks();
                        break;
                    case 4:
                        Console.Clear();
                        GetAllBooksByAuthor();
                        break;
                    case 5:
                        Console.Clear();
                        DeleteBookByNumber(InputNunmberForDel());
                        break;
                    case 6:
                        Console.Clear();
                        flag = false;
                        break;
                    default:
                        break;
                }
            } while (flag);
        }

        private static void AddBook()
        {
            _context = new BookContext();
            Random rnd = new Random();
            Console.WriteLine("Input a book name:");
            string bookName = Console.ReadLine();
            Console.WriteLine("Input a release year of book:");
            int releaseYear = Int32.Parse(Console.ReadLine());
            Console.WriteLine("How many authors?");
            int authCount = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < authCount; i++)
            {
                Console.WriteLine("Input an author last name:");
                string lastName = Console.ReadLine();
                _context.Books.Add(new Book()
                {
                    BookId = Guid.NewGuid().ToString(),
                    BookNumber = rnd.Next(0, 100000),
                    BookName = bookName,
                    ReleaseYear = releaseYear,
                    AuthorNumber = rnd.Next(0, 100000),
                    AuthorLastName = lastName
                });
            }
            _context.SaveChanges();
            Console.Clear();
            Console.WriteLine("Added");
        }

        private static void GetAllAuthors()
        {
            _context = new BookContext();
            var listAuthors = _context.Books.Select(auth => new {
                auth.AuthorLastName,
                auth.AuthorNumber
            }).ToList();

            foreach (var a in listAuthors)
            {
                Console.WriteLine(a.AuthorNumber + "\t" + a.AuthorLastName);
            }
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
            Console.Clear();
        }

        private static void GetAllBooks()
        {
            _context = new BookContext();
            var listAuthors = _context.Books.Select(book => new {
                book.BookNumber,
                book.BookName,
                book.ReleaseYear,
                book.AuthorLastName
            }).ToList();

            foreach (var a in listAuthors)
            {
                Console.WriteLine(a.BookNumber + "\t" + a.BookName + "\t" + a.AuthorLastName + "\t" + a.ReleaseYear);
            }
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
            Console.Clear();
        }

        private static void GetAllBooksByAuthor()
        {
            Console.WriteLine("Input an author number: ");
            int authNumber = Int32.Parse(Console.ReadLine());
            _context = new BookContext();
            var listAuthors = _context.Books.Where(auth => auth.AuthorNumber == authNumber).Select(book => new {
                book.BookNumber,
                book.BookName,
                book.ReleaseYear,
                book.AuthorLastName
            }).ToList();

            if (!listAuthors.Any())
            {
                Console.WriteLine("Not found!");
            }
            else
            {
                foreach (var a in listAuthors)
                {
                    Console.WriteLine(a.BookNumber + "\t" + a.BookName + "\t" + a.AuthorLastName + "\t" + a.ReleaseYear);
                }
            }
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
            Console.Clear();
        }

        private static void DeleteBookByNumber(int delNumber)
        {
            _context = new BookContext();
            var delVal = _context.Books.Where(del => del.BookNumber == delNumber).FirstOrDefault();
            if (delVal == null)
            {
                Console.Clear();
                Console.WriteLine("Not Found!");
            }
            else
            {
                _context.Books.Remove(delVal);
                _context.SaveChanges();
                Console.Clear();
                Console.WriteLine("Deleted");
            }
        }

        private static int InputNunmberForDel()
        {
            Console.WriteLine("Input a number of book for delete: ");
            int delNumber = Int32.Parse(Console.ReadLine());
            return delNumber;
        }
    }
}

