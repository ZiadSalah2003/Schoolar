using Microsoft.EntityFrameworkCore;
using Schoolar.Data.Entities;
using Schoolar.infrastructure.Abstracts;
using Schoolar.infrastructure.Bases;
using Schoolar.infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.infrastructure.Repositories
{
	public class StudentRepository : Repository<Student>, IStudentRepository
	{
		private readonly DbSet<Student> _student;
		public StudentRepository(ApplicationDbContext context) : base(context)
		{
			_student = context.Set<Student>();
		}
		public async Task<List<Student>> GetStudentsAsync()
		{
			return await _student.Include(x => x.Department).ToListAsync();
		}
	}
}
