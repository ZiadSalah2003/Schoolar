using FluentValidation;
using Schoolar.Core.Features.Students.Commands.Models;
using Schoolar.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Core.Features.Students.Commands.Validators
{
	public class EditStudentValidator : AbstractValidator<EditStudentCommand>
	{
		private readonly IStudentService _studentService;
		public EditStudentValidator(IStudentService studentService)
		{
			_studentService = studentService;
			ApplyValidationsRules();
			ApplyCustomValidationsRules();
		}
		public void ApplyValidationsRules()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Name must not be empty")
				.NotNull().WithMessage("Name must not be null")
				.MaximumLength(10).WithMessage("max length is 10");

			RuleFor(x => x.Address)
				.NotEmpty().WithMessage("{PropertyName} must not be empty")
				.NotNull().WithMessage("{PropertyName} must not be null")
				.MaximumLength(10).WithMessage("{PropertyName} length is 10");
		}

		public void ApplyCustomValidationsRules()
		{
			RuleFor(x => x.Name)
				.MustAsync(async (model,Key, CancellationToken) => !await _studentService.IsNameExistExcludeSelf(Key,model.Id))
				.WithMessage("Name Is Exist");
		}
	}
}
