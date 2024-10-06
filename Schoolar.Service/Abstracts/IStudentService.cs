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
		public Task<Student> GetStudentByIdWithIncludeAsync(int id);
		public Task<Student> GetStudentByIdAsync(int id);
		public Task<string> CreateStudentAsync(Student student);
		public Task<bool> IsNameExist(string name);
		public Task<bool> IsNameExistExcludeSelf(string name, int id);
		public Task<string> EditStudentAsync(Student student);
		public Task<string> DeleteStudentAsync(Student student);
	}
}
