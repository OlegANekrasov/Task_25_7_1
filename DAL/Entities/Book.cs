using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_25_7_1.DAL.Entities
{
    public class Book       
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime YearOfIssue { get; set; }
        public BookGenre BookGenre { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        public List<UserBook> UserBooks { get; set; } = null!;
    }

    public enum BookGenre
    {
        роман,
        рассказ,
        повесть,
        поэма,
        неизвестен
    }
}
