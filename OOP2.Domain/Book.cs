using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; } = null!;
        public string Title { get; set; } = null!;

        public Guid GenreId { get; set; }
        public Genre? Genre { get; set; } 

        public Guid WriterId { get; set; }
    public List<Writer> Writers { get; set; } = new();
	
    }
}
