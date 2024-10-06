using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schoolar.API.Bases;
using Schoolar.Core.Features.Students.Commands.Models;
using Schoolar.Core.Features.Students.Queries.Models;
using Schoolar.Data.Entities;
using Route = Schoolar.Data.AppMetaData.Route;

namespace Schoolar.API.Controllers
{
	//[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : AppControllerBases
	{
		[HttpGet(Route.StudentRoute.GetStudents)]
		public async Task<IActionResult> GetStudents()
		{
			var result = await Mediator.Send(new GetStudentsQuery());
			return Ok(result);
		}
		[HttpGet(Route.StudentRoute.GetStudentById)]
		public async Task<IActionResult> GetStudentById([FromRoute] int id)
		{
			var result = await Mediator.Send(new GetStudentByIdQuery(id));
			return NewResult(result);
		}

		[HttpPost(Route.StudentRoute.CreateStudent)]
		public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand student)
		{
			var result = await Mediator.Send(student);
			return NewResult(result);
		}

		[HttpPut(Route.StudentRoute.EditStudent)]
		public async Task<IActionResult> UpdateStudent([FromBody] EditStudentCommand student)
		{
			var result = await Mediator.Send(student);
			return NewResult(result);
		}
		[HttpDelete(Route.StudentRoute.DeleteStudent)]
		public async Task<IActionResult> DeleteStudent([FromBody] int id)
		{
			var result = await Mediator.Send(new DeleteStudentCommand(id));
			return NewResult(result);
		}

	}
}
