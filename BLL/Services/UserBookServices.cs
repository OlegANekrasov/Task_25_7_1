using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.DAL.Entities;
using Task_25_7_1.DAL.Repositories;

namespace Task_25_7_1.BLL.Services
{
    public class UserBookServices
    {
        UserBookRepository userBookRepository = null!;

        public UserBookServices()
        {
            userBookRepository = new UserBookRepository();
        }

        public IEnumerable<UserBook> SelectAll()
        {
            return userBookRepository.SelectAll();
        }

        public void IssueBookToUser(int idUser, int idBook)
        {
            userBookRepository.IssueBookToUser(idUser, idBook);
        }

        public void BookReturn(int idUser, int idBook)
        {
            userBookRepository.BookReturn(idUser, idBook);
        }

        public bool CheckBookOfAuthorAndTitleInUser(string аuthorStr, string name)
        {
            return userBookRepository.CheckBookOfAuthorAndTitleInUser(аuthorStr, name);
        }
    }
}
