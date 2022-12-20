using Microsoft.EntityFrameworkCore;
using OOP2.Domain.Models;
using OOP2.Infrastructure.Data;

namespace OOP2.Infrastructure.Repository
{
    public class WriterRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public WriterRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Writer>> GetAllWritersAsync()
        {
            return await _context.Writers.ToListAsync();
        }
        public async Task<Writer?> GetWriterByIdAsync(Guid id)
        {
            return await _context.Writers.Where(b => b.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Writer?> GetWriterByNameAsync(string name)
        {
            return await _context.Writers
                .Where(w => w.Name == name)
                .FirstOrDefaultAsync();
        }

        public async Task AddWriterAsync(Writer writer)
        {
            await _context.Writers.AddAsync(writer);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateWriterAsync(Writer writer)
        {
            var existWriter = GetWriterByIdAsync(writer.Id).Result;
            if (existWriter != null)
            {
                _context.Entry(existWriter).CurrentValues.SetValues(writer);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteWriterAsync(Guid id)
        {
            var existWriter = GetWriterByIdAsync(id).Result;
            if (existWriter != null)
            {
                _context.Remove(existWriter);
                await _context.SaveChangesAsync();
            }
        }
        public void ChangeTrackerClear()
        {
            _context.ChangeTracker.Clear();
        }
        
        
        
        
    }
}
