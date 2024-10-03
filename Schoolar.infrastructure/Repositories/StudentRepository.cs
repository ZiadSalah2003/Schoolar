using Microsoft.EntityFrameworkCore;
using Schoolar.Data.Entities;
using Schoolar.infrastructure.Abstracts;
using Schoolar.infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.infrastructure.Repositories
{
	public class StudentRepository : IStudentRepository
	{
		private readonly ApplicationDbContext _context;
		public StudentRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<List<Student>> GetStudentsAsync()
		{
			return await _context.Students.Include(x => x.Department).ToListAsync();
		}
	}
}
