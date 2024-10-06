using Microsoft.EntityFrameworkCore;
using Schoolar.Data.Entities;
using Schoolar.infrastructure.Abstracts;
using Schoolar.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Service.Implementations
{
	public class StudentService : IStudentService
	{
		private readonly IStudentRepository _studentRepository;
		public StudentService(IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
		}
		public async Task<List<Student>> GetStudentsAsync()
		{
			return await _studentRepository.GetStudentsAsync();
		}
		public async Task<Student> GetStudentByIdAsync(int id)
		{
			var student = _studentRepository.GetTableNoTracking().Include(d => d.Department).Where(x => x.StudentId == id).FirstOrDefault();
			return student;
		}
		public async Task<string> CreateStudentAsync(Student student)
		{
			var nameIsExist = _studentRepository.GetTableNoTracking().Where(x => x.Name == student.Name).FirstOrDefault();
			if (nameIsExist is not null)
				return "Exist";

			if (student.DepartmentId == null)
				student.DepartmentId = null;

			await _studentRepository.AddAsync(student);
			return "Success";
		}
	}
}
