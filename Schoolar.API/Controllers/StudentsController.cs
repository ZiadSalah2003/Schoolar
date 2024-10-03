using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schoolar.Core.Features.Students.Queries.Models;

namespace Schoolar.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly IMediator _mediator;
        public StudentsController(IMediator mediator)
        {
			_mediator = mediator;
		}
		[HttpGet("")]
		public async Task<IActionResult> GetStudent()
		{
			var result = await _mediator.Send(new GetStudentsQuery());
			return Ok(result);
		}
    }
}
