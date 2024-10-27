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
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DepartmetSubject>().HasKey(x => new { x.DepartmetId, x.SubjectId });
			modelBuilder.Entity<StudentSubject>().HasKey(x => new { x.StudentId, x.SubjectId });
			modelBuilder.Entity<InstructorSubject>().HasKey(x => new { x.InstructorId, x.SubjectId });

			modelBuilder.Entity<Instructor>().HasOne(x => x.Supervisor).WithMany(x => x.Instructors).HasForeignKey(x => x.SupervisorId).OnDelete(DeleteBehavior.Restrict);
			modelBuilder.Entity<Department>().HasOne(x => x.Instructor).WithOne(x => x.departmentManager).HasForeignKey<Department>(x => x.InstructorManger).OnDelete(DeleteBehavior.Restrict);

			base.OnModelCreating(modelBuilder);
		}
	}
}
