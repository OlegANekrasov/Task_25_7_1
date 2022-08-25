using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.DAL.DB;
using Task_25_7_1.DAL.Entities;

namespace Task_25_7_1.DAL.Repositories
{
    public class AuthorRepository
    {
        public IEnumerable<Author> SelectAll()
        {
            using (var db = new AppContextDB())
            {
                return db.Authors.Include(t => t.Books).ToList();
            }
        }

        public Author SelectByID(int id)
        {
            using (var db = new AppContextDB())
            {
                return db.Authors.Include(t => t.Books).FirstOrDefault(u => u.Id == id);
            }
        }

        public Author SelectByName(string name)
        {
            using (var db = new AppContextDB())
            {
                return db.Authors.Include(t => t.Books).FirstOrDefault(u => u.FullName == name);
            }
        }

        public IEnumerable<Book> SelectBooksByID(int id)
        {
            using (var db = new AppContextDB())
            {
                var author = db.Authors.Include(t => t.Books).FirstOrDefault(u => u.Id == id);
                if (author != null)
                {
                    return author.Books;
                }
                return null;
            }
        }
    }
}
