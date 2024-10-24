using FluentValidation;
using Microsoft.Extensions.Localization;
using Schoolar.Core.Features.Students.Commands.Models;
using Schoolar.Core.Resources;
using Schoolar.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Core.Features.Students.Commands.Validators
{
	public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
	{
		private readonly IStudentService _studentService;
		private readonly IStringLocalizer<SharedResources> _localizer;
		public CreateStudentValidator(IStudentService studentService, IStringLocalizer<SharedResources> localizer)
        {
			_studentService = studentService;
			_localizer = localizer;
			ApplyValidationsRules();
			ApplyCustomValidationsRules();
		}

		public void ApplyValidationsRules()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
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
				.MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key))
				.WithMessage("Name Is Exist");
		}

	}
}
