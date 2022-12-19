using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.Domain
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;



		/*
        public Guid BookId { get; set; }
        public Book BookTitle { get; set; } = null!;
        
        public Guid WriterId { get; set; } = Guid.Empty;
        public Writer Writer { get; set; } = null!;*/
	}
}
