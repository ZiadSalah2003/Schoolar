using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Core.Bases
{
	public class ResponseHandler
	{
		//private readonly IStringLocalizer<SharedResources> _stringLocalizer;
		//public ResponseHandler(IStringLocalizer<SharedResources> stringLocalizer)
		//{
		//	_stringLocalizer = stringLocalizer;
		//}
		public Response<T> Deleted<T>()
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.OK,
				Succeeded = true,
				Message = "Delete Successfully"
			};
		}
		public Response<T> Success<T>(T entity, object Meta = null)
		{
			return new Response<T>()
			{
				Data = entity,
				StatusCode = System.Net.HttpStatusCode.OK,
				Succeeded = true,
				Message = "Added Successfully",
				Meta = Meta
			};
		}
		public Response<T> Unauthorized<T>()
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.Unauthorized,
				Succeeded = true,
				Message = "Unauthorized"
			};
		}
		public Response<T> BadRequest<T>(string message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.BadRequest,
				Succeeded = false,
				Message = message == null ? "BadRequest" : message
			};
		}
		public Response<T> UnprocessableEntity<T>(string message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
				Succeeded = false,
				Message = message == null ? "UnprocessableEntity" : message
			};
		}
		public Response<T> NotFound<T>(string message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.NotFound,
				Succeeded = false,
				Message = message == null ? "NotFound" : message
			};
		}
		public Response<T> Created<T>(T entity, object Meta = null)
		{
			return new Response<T>()
			{
				Data = entity,
				StatusCode = System.Net.HttpStatusCode.Created,
				Succeeded = true,
				Message = "Created Successfully",
				Meta = Meta
			};
		}
	}
}
