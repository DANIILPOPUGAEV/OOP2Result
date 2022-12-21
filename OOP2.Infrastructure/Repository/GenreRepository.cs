using OOP2.Domain.Models;
using OOP2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace OOP2.Infrastructure.Repository
{
	public class GenreRepository
	{
		private readonly Context _context;
		public Context UnitOfWork
		{
			get
			{
				return _context;
			}
		}
		public GenreRepository(Context context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}
		public async Task<List<Genre>> GetAllGenresAsync()
		{
			return await _context.Genres.ToListAsync();
		}
		public async Task<Genre?> GetGenreByIDAsync(Guid Id)
		{
			return await _context.Genres.Where(g => g.Id == Id).FirstOrDefaultAsync();
		}
		public async Task AddGenreAsync(Genre genre)
		{
			await _context.Genres.AddAsync(genre);
			await _context.SaveChangesAsync();
		}
		public async Task UpdateGenreAsync(Genre genre)
		{
			var existGenre = GetGenreByIdAsync(genre.Id).Result;
			if (existGenre != null)
			{
				_context.Entry(existGenre).CurrentValues.SetValues(genre);
				await _context.SaveChangesAsync();
			}
		}
	}
}
