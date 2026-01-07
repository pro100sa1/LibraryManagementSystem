using LibraryManagementSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace LibraryManagementSystem.DAL.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private const int ID_length = 5;
        private const int TITLE_Length = 30;
        private const int AUTHOR_Length = 25;
        private const int ISBN_Length = 13;
        private const int YEAR_Length = 4;
        private const int CATEGORY_Length = 5;
        private const int AVAILABLE_Length = 1;

        private readonly string filePath = "Data/books.txt";

        // ---------------- Add ----------------
        public void Add(Book book)
        {
            string line =
                book.Id.ToString().PadLeft(ID_length, '0') +
                book.Title.PadRight(TITLE_Length) +
                book.Author.PadRight(AUTHOR_Length) +
                book.ISBN.PadRight(ISBN_Length) +
                book.PublishedYear.ToString().PadLeft(YEAR_Length, '0') +
                book.CategoryId.ToString().PadLeft(CATEGORY_Length, '0') +
                (book.IsAvailable ? "1" : "0");

            File.AppendAllText(filePath, line + Environment.NewLine);
        }

        // ---------------- GetAll ----------------
        public List<Book> GetAll()
        {
            List<Book> books = new List<Book>();

            if (!File.Exists(filePath))
                return books;

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                Book book = new Book
                {
                    Id = int.Parse(line.Substring(0, ID_length)),
                    Title = line.Substring(ID_length, TITLE_Length).Trim(),
                    Author = line.Substring(ID_length + TITLE_Length, AUTHOR_Length).Trim(),
                    ISBN = line.Substring(ID_length + TITLE_Length + AUTHOR_Length, ISBN_Length).Trim(),
                    PublishedYear = int.Parse(line.Substring(ID_length + TITLE_Length + AUTHOR_Length + ISBN_Length, YEAR_Length)),
                    CategoryId = int.Parse(line.Substring(ID_length + TITLE_Length + AUTHOR_Length + ISBN_Length + YEAR_Length, CATEGORY_Length)),
                    IsAvailable = line.Substring(ID_length + TITLE_Length + AUTHOR_Length + ISBN_Length + YEAR_Length + CATEGORY_Length, AVAILABLE_Length) == "1"
                };
                books.Add(book);
            }

            return books;
        }

        
        public Book GetById(int id)
        {
            List<Book> books = GetAll();

            foreach (Book book in books)
            {
                if (book.Id == id)
                    return book;
            }

            return null;
        }

       
        public void Update(Book entity)
        {
            List<Book> books = GetAll();
            bool updated = false;

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Id == entity.Id)
                {
                    books[i] = entity;
                    updated = true;
                    break;
                }
            }

            if (updated)
            {
                using (StreamWriter sw = new StreamWriter(filePath, false))
                {
                    foreach (Book b in books)
                    {
                        string line =
                            b.Id.ToString().PadLeft(ID_length, '0') +
                            b.Title.PadRight(TITLE_Length) +
                            b.Author.PadRight(AUTHOR_Length) +
                            b.ISBN.PadRight(ISBN_Length) +
                            b.PublishedYear.ToString().PadLeft(YEAR_Length, '0') +
                            b.CategoryId.ToString().PadLeft(CATEGORY_Length, '0') +
                            (b.IsAvailable ? "1" : "0");

                        sw.WriteLine(line);
                    }
                }
            }
        }

        
        public void Delete(int id)
        {
            List<Book> books = GetAll();

            books.RemoveAll(b => b.Id == id);

            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach (Book b in books)
                {
                    string line =
                        b.Id.ToString().PadLeft(ID_length, '0') +
                        b.Title.PadRight(TITLE_Length) +
                        b.Author.PadRight(AUTHOR_Length) +
                        b.ISBN.PadRight(ISBN_Length) +
                        b.PublishedYear.ToString().PadLeft(YEAR_Length, '0') +
                        b.CategoryId.ToString().PadLeft(CATEGORY_Length, '0') +
                        (b.IsAvailable ? "1" : "0");

                    sw.WriteLine(line);
                }
            }
        }

      
        public List<Book> Search(string keyword)
        {
            List<Book> allBooks = GetAll();
            List<Book> result = new List<Book>();

            foreach (Book book in allBooks)
            {
                if ((book.Title != null && book.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)) ||
                    (book.Author != null && book.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase)) ||
                    (book.ISBN != null && book.ISBN.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
                {
                    result.Add(book);
                }
            }

            return result;
        }
    }
}
