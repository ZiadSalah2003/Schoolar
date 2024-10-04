using Schoolar.Data.Entities;
using Schoolar.infrastructure.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.infrastructure.Abstracts
{
	public interface IStudentRepository : IRepository<Student>
	{
		public Task<List<Student>> GetStudentsAsync();
	}
}
