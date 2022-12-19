using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OOP2.Domain;
using OOP2.Infrastructure.Data;
using OOP2.Infrastructure.Repository;

namespace OOP2.Test
{
    public class Helper
    {
        public readonly Context _context;
        
        public Helper()
        {
            var contextOption = new DbContextOptionsBuilder<Context>()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=OOP2Test").Options;
            _context = new Context(contextOption);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            var writer = new Writer
            {
                Name = "Александр",
                SecondName = "Блок",
                Patronymic = "Александрович"
            };

            _context.Writers.Add(writer);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        public WriterRepository WriterRepository
        {
            get
            {
                return new WriterRepository(_context);
            }
        }
    }
}
