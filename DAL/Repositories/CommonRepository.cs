using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.DAL.DB;
using Task_25_7_1.DAL.Entities;

namespace Task_25_7_1.DAL.Repositories
{
    public class CommonRepository
    {
        public void InitializationBD()
        {
            using (var db = new AppContextDB())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var user1 = new User { Name = "Иванов И.И.", Email = "Ivanov@mail.ru" };
                var user2 = new User { Name = "Петров П.П.", Email = "Petrov@mail.ru" };
                var user3 = new User { Name = "Сидоров С.С.", Email = "Sidorov@mail.ru" };

                db.Users.AddRange(user1, user2, user3);

                var author1 = new Author { FullName = "Ф. М. ДОСТОЕВСКИЙ" };
                var author2 = new Author { FullName = "А. П. ЧЕХОВ" };
                var author3 = new Author { FullName = "Н. В. ГОГОЛЬ" };

                db.Authors.AddRange(author1, author2, author3);
                db.SaveChanges();

                var book1 = new Book { Name = "БЕСЫ", Author = author1, YearOfIssue = new DateTime(1871, 1, 1), BookGenre = BookGenre.роман };
                var book2 = new Book { Name = "ДВОЙНИК", Author = author1, YearOfIssue = new DateTime(1846, 1, 1), BookGenre = BookGenre.повесть };
                var book3 = new Book { Name = "ЗЛОУМЫШЛЕННИК", Author = author2, YearOfIssue = new DateTime(1885, 1, 1), BookGenre = BookGenre.рассказ };
                var book4 = new Book { Name = "ЕГЕРЬ", Author = author2, YearOfIssue = new DateTime(1885, 1, 1), BookGenre = BookGenre.рассказ };
                var book5 = new Book { Name = "КОЛЯСКА", Author = author3, YearOfIssue = new DateTime(1836, 1, 1), BookGenre = BookGenre.повесть };
                var book6 = new Book { Name = "ШИНЕЛЬ", Author = author3, YearOfIssue = new DateTime(1842, 1, 1), BookGenre = BookGenre.повесть };

                db.Books.AddRange(book1, book2, book3, book4, book5, book6);
                db.SaveChanges();
            }
        }
    }
}
