using OOP2.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
