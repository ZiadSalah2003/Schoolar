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
	}
}
