using Microsoft.EntityFrameworkCore;
using Schoolar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.infrastructure.Persistence
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Department> Departments { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Subjects> Subjects { get; set; }
		public DbSet<DepartmetSubject> DepartmetSubjects { get; set; }
		public DbSet<StudentSubject> StudentSubjects { get; set; }
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
	}
}
