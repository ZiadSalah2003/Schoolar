using Schoolar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Service.Abstracts
{
	public interface IStudentService
	{
		public Task<List<Student>> GetStudentsAsync();
		public Task<Student> GetStudentByIdAsync(int id);
		public Task<string> CreateStudentAsync(Student student);
	}
}
