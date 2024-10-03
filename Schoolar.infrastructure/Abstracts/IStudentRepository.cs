using Schoolar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.infrastructure.Abstracts
{
	public interface IStudentRepository
	{
		public Task<List<Student>> GetStudentsAsync();
	}
}
