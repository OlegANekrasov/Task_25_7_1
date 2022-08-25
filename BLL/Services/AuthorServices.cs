using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.DAL.Repositories;

namespace Task_25_7_1.BLL.Services
{
    public class AuthorServices
    {
        AuthorRepository authorRepository = null!;

        public AuthorServices()
        {
            authorRepository = new AuthorRepository();
        }


    }
}
