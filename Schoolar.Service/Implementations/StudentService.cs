﻿using Microsoft.EntityFrameworkCore;
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
		public async Task<Student> GetStudentByIdWithIncludeAsync(int id)
		{
			var student = _studentRepository.GetTableNoTracking().Include(d => d.Department).Where(x => x.StudentId == id).FirstOrDefault();
			return student;
		}
		public async Task<Student> GetStudentByIdAsync(int id)
		{
			var student = _studentRepository.GetTableNoTracking().Where(x => x.StudentId == id).FirstOrDefault();
			return student;
		}

		public async Task<string> CreateStudentAsync(Student student)
		{
			if (student.DepartmentId == null)
				student.DepartmentId = null;

			await _studentRepository.AddAsync(student);
			return "Success";
		}
		public async Task<bool> IsNameExist(string name)
		{
			var student = _studentRepository.GetTableNoTracking().Where(x => x.Name == name).FirstOrDefault();
			if (student is not null)
				return true;
			return false;
		}

		public async Task<bool> IsNameExistExcludeSelf(string name, int id)
		{
			var student = _studentRepository.GetTableNoTracking().Where(x => x.Name == name && x.StudentId != id).FirstOrDefault();
			if (student is not null)
				return true;
			return false;
		}
		public async Task<string> EditStudentAsync(Student student)
		{
			await _studentRepository.UpdateAsync(student);
			return "Success";
		}
		public async Task<string> DeleteStudentAsync(Student student)
		{
			var transaction = _studentRepository.BeginTransaction();
			try
			{
				await _studentRepository.DeleteAsync(student);
				await transaction.CommitAsync();
				return "Success";
			}
			catch
			{
				await transaction.RollbackAsync();
				return "Falied";
			}
			
			
		}
	}
}
