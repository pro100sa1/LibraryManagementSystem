using LibraryManagementSystem.BLL;
using LibraryManagementSystem.DAL.Entities;
using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.UI
{
    public static class BookUI
    {
        private static BookService bookService = new BookService();

        public static void AddBookUI()
        {
            try
            {
                int id = bookService.GetNewBookId();
                Console.WriteLine($"Avtomatik ID: {id}");

                Console.Write("Kitabin Adi: ");
                string title = Console.ReadLine();

                Console.Write("Muellif: ");
                string author = Console.ReadLine();

                Console.Write("ISBN (13 simvol): ");
                string isbn = Console.ReadLine();

                Console.Write("Yayin ili: ");
                int year = int.Parse(Console.ReadLine());

              
                if (year > DateTime.Now.Year)
                {
                    throw new Exception("Kitab gelecekde yazila bilmez!");
                }

                Console.Write("Kateqoriya ID: ");
                int catId = int.Parse(Console.ReadLine());

                Console.Write("Mövcuddur? (1 = Beli, 0 = Xeyr): ");
                bool isAvailable = Console.ReadLine() == "1";

                Book book = new Book
                {
                    Id = id,
                    Title = title,
                    Author = author,
                    ISBN = isbn,
                    PublishedYear = year,
                    CategoryId = catId,
                    IsAvailable = isAvailable
                };

                bookService.AddBook(book);

                Console.WriteLine("Kitab ugurla elave olundu!");
                Console.WriteLine("Enter basin...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Xeta: " + ex.Message);
                Console.WriteLine("Enter basin...");
                Console.ReadLine();
            }
        }

        


        public static void ListBooksUI()
        {
            Console.Clear();

            string header = "BOOK LIST";
            Console.WriteLine(header.PadLeft((Console.WindowWidth + header.Length) / 2));
            Console.WriteLine();

            var books = bookService.GetAllBooks();

            Console.Clear();
            Console.WriteLine("============== BOOK LIST ==============");
            Console.WriteLine(
                "ID".PadRight(5) +
                "TITLE".PadRight(20) +
                "AUTHOR".PadRight(20) +
                "YEAR".PadRight(8) +
                "CAT ID".PadRight(8) +
                "STATUS"
            );
            Console.WriteLine(new string('-', 70));

            foreach (var b in books)
            {
                Console.WriteLine(
                    b.Id.ToString().PadRight(5) +
                    b.Title.PadRight(20) +
                    b.Author.PadRight(20) +
                    b.PublishedYear.ToString().PadRight(8) +
                    b.CategoryId.ToString().PadRight(8) +
                    (b.IsAvailable ? "Available" : "Not Available")
                );
            }

            Console.WriteLine("Enter basin...");
            Console.ReadLine();
        }
        

        public static void GetBookByIdUI()
        {
            Console.Write("Kitab ID daxil edin: ");
            int id = int.Parse(Console.ReadLine());

            Book book = bookService.GetBookById(id);

            if (book != null)
            {
                Console.WriteLine($"ID: {book.Id} | Title: {book.Title} | Author: {book.Author} | ISBN: {book.ISBN} | Year: {book.PublishedYear} | CategoryID: {book.CategoryId} | Available: {(book.IsAvailable ? "Beli" : "Xeyr")}");
            }
            else
            {
                Console.WriteLine("Kitab tapilmadi!");
            }
            Console.WriteLine("Enter basin...");
            Console.ReadLine();
        }

        public static void UpdateBookUI()
        {
            try
            {
                Console.Write("Yenilemek istediyiniz kitab ID: ");
                int id = int.Parse(Console.ReadLine());

                Book book = bookService.GetBookById(id);
                if (book == null)
                {
                    Console.WriteLine("Kitab tapilmadi! Enter basin...");
                    Console.ReadLine();
                    return;
                }

                Console.Write($"Yeni Title ({book.Title}): ");
                string title = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(title)) book.Title = title;

                Console.Write($"Yeni Author ({book.Author}): ");
                string author = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(author)) book.Author = author;

                Console.Write($"Yeni ISBN ({book.ISBN}): ");
                string isbn = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(isbn)) book.ISBN = isbn;

                Console.Write($"Yeni Year ({book.PublishedYear}): ");
                string yearInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(yearInput)) book.PublishedYear = int.Parse(yearInput);

                Console.Write($"Yeni CategoryID ({book.CategoryId}): ");
                string catInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(catInput)) book.CategoryId = int.Parse(catInput);

                Console.Write($"Mövcuddur? ({(book.IsAvailable ? "Beli" : "Xeyr")}) (1/0): ");
                string availInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(availInput)) book.IsAvailable = availInput == "1";

                bookService.UpdateBook(book);

                Console.WriteLine("Kitab yenilendi! Enter basin...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Xeta: " + ex.Message);
                Console.WriteLine("Enter basin...");
                Console.ReadLine();
            }
        }

        public static void DeleteBookUI()
        {
            Console.Write("Silmek istediyiniz kitab ID: ");
            int id = int.Parse(Console.ReadLine());

            bookService.DeleteBook(id);

            Console.WriteLine("Kitab silindi! Enter basin...");
            Console.ReadLine();
        }
        public static void SearchBookUI()
        {
            Console.Clear();
            Console.Write("Axtarilacaq soz: ");
            string keyword = Console.ReadLine();

            var results = bookService.SearchBooks(keyword);

            Console.Clear();
            Console.WriteLine("=========== SEARCH RESULT ===========");
            Console.WriteLine(
                "ID".PadRight(5) +
                "TITLE".PadRight(20) +
                "AUTHOR".PadRight(20) +
                "YEAR".PadRight(8) +
                "STATUS"
            );
            Console.WriteLine(new string('-', 65));

            if (results.Count == 0)
            {
                Console.WriteLine("Netice tapilmadi!");
            }
            else
            {
                foreach (var b in results)
                {
                    Console.Write(
                        b.Id.ToString().PadRight(5) +
                        b.Title.PadRight(20) +
                        b.Author.PadRight(20) +
                        b.PublishedYear.ToString().PadRight(8)
                    );

                   
                    if (b.IsAvailable)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Available");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Not Available");
                    }
                    Console.ResetColor();
                }
            }

            Console.WriteLine("\nEnter basin...");
            Console.ReadLine();
        }


    }
}
