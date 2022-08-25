using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.DAL.DB;
using Task_25_7_1.DAL.Entities;
using Task_25_7_1.PLL.Helpers;

namespace Task_25_7_1.DAL.Repositories
{
    public class BookRepository   
    {
        public IEnumerable<Book> SelectAll()
        {
            using (var db = new AppContextDB())
            {
                return db.Books.Include(t => t.Author).ToList();
            }
        }

        public Book SelectByID(int id)
        {
            using (var db = new AppContextDB())
            {
                return db.Books.Include(t => t.Author).FirstOrDefault(u => u.Id == id);
            }
        }

        public void AddBook(string name, string аuthorStr, int yearOfIssue, BookGenre bookGenre)
        {
            using (var db = new AppContextDB())
            {
                Author аuthor = db.Authors.Include(t => t.Books).FirstOrDefault(u => u.FullName == аuthorStr);
                if(аuthor == null)
                {
                    AlertMessage.Show("Не найден автор книги");
                    return;
                }

                try
                {
                    Book book = new Book { Name = name, Author = аuthor, YearOfIssue = new DateTime(yearOfIssue, 1, 1), BookGenre = bookGenre };
                    
                    db.Books.Add(book);
                    db.SaveChanges();

                    SuccessMessage.Show("Книга добавлена");
                }
                catch (Exception ex)
                {
                    AlertMessage.Show("Ошибка при добавлении книги... " + ex.Message);
                }
            }
        }
        
        public void DelBook(int id)
        {
            using (var db = new AppContextDB())
            {
                try
                {
                    var book = SelectByID(id);
                    if (book != null)
                    {
                        db.Books.Remove(book);
                        db.SaveChanges();
                        SuccessMessage.Show("Книга удалена");
                    }
                    else
                    {
                        AlertMessage.Show("Не найдена книга с данным Id");
                    }
                }
                catch (Exception)
                {
                    AlertMessage.Show("Ошибка при удалении книги");
                }
            }
        }
        
        public void BookYearUpdate(int id, int newYear)
        {
            using (var db = new AppContextDB())
            {
                try
                {
                    var book = SelectByID(id);
                    if (book != null)
                    {
                        book.YearOfIssue = new DateTime(newYear, 1, 1);
                        db.Books.Update(book);
                        db.SaveChanges();
                        SuccessMessage.Show("Год выпуска книги обновлен");
                    }
                    else
                    {
                        AlertMessage.Show("Не найдена книга с данным Id");
                    }
                }
                catch (Exception)
                {
                    AlertMessage.Show("Ошибка при обновлении книги");
                }
            }
        }
        
        public IEnumerable<Book> SelectBooksOfGenreAndYears(BookGenre bookGenre, int yearOfIssue1, int yearOfIssue2)
        {
            using (var db = new AppContextDB())
            {
                return db.Books.Include(t => t.Author)
                               .Where(o => o.BookGenre == bookGenre && o.YearOfIssue.Year >= yearOfIssue1 && o.YearOfIssue.Year <= yearOfIssue2)
                               .ToList();
            }
        }

        public int GetCountBooksByAuthor(string аuthorStr)
        {
            using (var db = new AppContextDB())
            {
                Author аuthor = db.Authors.Include(t => t.Books).FirstOrDefault(u => u.FullName == аuthorStr);
                if (аuthor == null)
                {
                    AlertMessage.Show("Не найден автор книги");
                    return 0;
                }
                
                return db.Books.Include(t => t.Author).Where(o => o.Author == аuthor).Count();
            }
        }

        public int GetCountBooksByGenre(BookGenre bookGenre)
        {
            using (var db = new AppContextDB())
            {
                return db.Books.Include(t => t.Author).Where(o => o.BookGenre == bookGenre).Count(); 
            }
        }

        public bool CheckBookOfAuthorAndTitle(string аuthorStr, string name)
        {
            using (var db = new AppContextDB())
            {
                Author аuthor = db.Authors.Include(t => t.Books).FirstOrDefault(u => u.FullName == аuthorStr);
                if (аuthor == null)
                {
                    AlertMessage.Show("Не найден автор книги");
                    return false;
                }

                if(db.Books.Include(t => t.Author).Where(o => o.Author == аuthor && o.Name == name).Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }
        
        public Book GetLatestPublishedBook()
        {
            using (var db = new AppContextDB())
            {
                return db.Books.Include(t => t.Author).OrderBy(o => o.YearOfIssue).Last();
            }
        }
        
        public IEnumerable<Book> GetAllBooksSortedByTitle()
        {
            using (var db = new AppContextDB())
            {
                return db.Books.Include(t => t.Author).OrderBy(o => o.Name).ToList();
            }
        }
        
        public IEnumerable<Book> GetAllBooksSortedByYearOfIssue()
        {
            using (var db = new AppContextDB())
            {
                return db.Books.Include(t => t.Author).OrderByDescending(o => o.YearOfIssue).ToList();
            }
        }
    }
}
