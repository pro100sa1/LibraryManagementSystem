using LibraryManagementSystem.DAL.Entities;
using LibraryManagementSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LibraryManagementSystem.BLL
{
    public class BookService
    {
        private readonly BookRepository _repo;

        public BookService()
        {
            _repo = new BookRepository();
        }

       
        public void AddBook(Book book)
        {
           
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new Exception("Title boş ola bilməz!");
            if (string.IsNullOrWhiteSpace(book.Author))
                throw new Exception("Author boş ola bilməz!");
            if (string.IsNullOrWhiteSpace(book.ISBN) || book.ISBN.Length != 13)
                throw new Exception("ISBN düzgün olmalıdır (13 simvol).");

            _repo.Add(book);
        }

      
        public List<Book> GetAllBooks()
        {
            return _repo.GetAll();
        }

      
        public Book GetBookById(int id)
        {
            return _repo.GetById(id);
        }

        
        public void UpdateBook(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new Exception("Title boş ola bilməz!");
            if (string.IsNullOrWhiteSpace(book.Author))
                throw new Exception("Author boş ola bilməz!");
            if (string.IsNullOrWhiteSpace(book.ISBN) || book.ISBN.Length != 13)
                throw new Exception("ISBN düzgün olmalıdır (13 simvol).");

            _repo.Update(book);
        }

      
        public void DeleteBook(int id)
        {
            _repo.Delete(id);
        }

     
        public List<Book> SearchBooks(string keyword)
        {
            return _repo.Search(keyword);
        }
    }
}
