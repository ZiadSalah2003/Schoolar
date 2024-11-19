using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schoolar.API.Bases;
using Schoolar.Core.Features.Departments.Queries.Models;

using Route = Schoolar.Data.AppMetaData.Route;
namespace Schoolar.API.Controllers
{
	//[Route("api/[controller]")]
	[ApiController]
	public class DepartmentsController : AppControllerBases
	{
		[HttpGet(Route.DepartmentRouting.GetByID)]
		public async Task<IActionResult> GetStudentById([FromRoute] int id)
		{
			var result = await Mediator.Send(new GetDepartmentByIdQuery(id));
			return NewResult(result);
		}
	}
}
