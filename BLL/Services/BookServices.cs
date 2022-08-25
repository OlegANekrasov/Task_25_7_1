using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.DAL.Entities;
using Task_25_7_1.DAL.Repositories;

namespace Task_25_7_1.BLL.Services
{
    public class BookServices
    {
        BookRepository bookRepository = null!;
        AuthorRepository authorRepository = null!;

        public BookServices()
        {
            bookRepository = new BookRepository();
            authorRepository = new AuthorRepository();
        }

        private BookGenre DoOperation(string bookGenreStr) => bookGenreStr switch
        {
            "роман" => BookGenre.роман,
            "рассказ" => BookGenre.рассказ,
            "повесть" => BookGenre.повесть,
            "поэма" => BookGenre.поэма,
            _ => BookGenre.неизвестен
        };

        public IEnumerable<Book> SelectAll()
        {
            return bookRepository.SelectAll();
        }

        public Book SelectByID(int id)
        {
            return bookRepository.SelectByID(id);
        }

        public void AddBook(string name, string аuthorStr, int yearOfIssue, string bookGenreStr)
        {
            BookGenre bookGenre = DoOperation(bookGenreStr);
            bookRepository.AddBook(name, аuthorStr, yearOfIssue, bookGenre);
        }

        public void DelBook(int id)
        {
            bookRepository.DelBook(id);
        }

        public void BookYearUpdate(int id, int newYear)
        {
            bookRepository.BookYearUpdate(id, newYear); 
        }

        public IEnumerable<Book> SelectBooksOfGenreAndYears(string bookGenreStr, int yearOfIssue1, int yearOfIssue2)
        {
            BookGenre bookGenre = DoOperation(bookGenreStr);
            return bookRepository.SelectBooksOfGenreAndYears(bookGenre, yearOfIssue1, yearOfIssue2); 
        }

        public int GetCountBooksByAuthor(string аuthorStr)
        {
            return bookRepository.GetCountBooksByAuthor(аuthorStr);
        }

        public int GetCountBooksByGenre(string bookGenreStr)
        {
            BookGenre bookGenre = DoOperation(bookGenreStr);
            return bookRepository.GetCountBooksByGenre(bookGenre); 
        }

        public bool CheckBookOfAuthorAndTitle(string аuthorStr, string name)
        {
            return bookRepository.CheckBookOfAuthorAndTitle(аuthorStr, name);
        }

        public Book GetLatestPublishedBook()
        {
            return bookRepository.GetLatestPublishedBook();
        }
        
        public IEnumerable<Book> GetAllBooksSortedByTitle()
        {
            return bookRepository.GetAllBooksSortedByTitle();
        }
        
        public IEnumerable<Book> GetAllBooksSortedByYearOfIssue()
        {
            return bookRepository.GetAllBooksSortedByYearOfIssue();
        }
    }
}
