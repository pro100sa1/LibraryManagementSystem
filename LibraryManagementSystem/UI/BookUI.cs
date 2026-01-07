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
                Console.Write("Kitabin ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Kitabin Adi: ");
                string title = Console.ReadLine();

                Console.Write("Muellif: ");
                string author = Console.ReadLine();

                Console.Write("ISBN (13 simvol): ");
                string isbn = Console.ReadLine();

                Console.Write("Yayin ili: ");
                int year = int.Parse(Console.ReadLine());

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

                Console.WriteLine("Kitab ugurla elave olundu! Enter basin...");
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
            List<Book> books = bookService.GetAllBooks();
            foreach (var b in books)
            {
                Console.WriteLine($"ID: {b.Id} | Title: {b.Title} | Author: {b.Author} | ISBN: {b.ISBN} | Year: {b.PublishedYear} | CategoryID: {b.CategoryId} | Available: {(b.IsAvailable ? "Beli" : "Xeyr")}");
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
            Console.Write("Axtarish sozunu daxil edin: ");
            string keyword = Console.ReadLine();

            List<Book> books = bookService.SearchBooks(keyword);

            foreach (var b in books)
            {
                Console.WriteLine($"ID: {b.Id} | Title: {b.Title} | Author: {b.Author} | ISBN: {b.ISBN} | Year: {b.PublishedYear} | CategoryID: {b.CategoryId} | Available: {(b.IsAvailable ? "Beli" : "Xeyr")}");
            }

            Console.WriteLine("Enter basin...");
            Console.ReadLine();
        }
    }
}
