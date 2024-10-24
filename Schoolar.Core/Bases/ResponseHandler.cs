using Microsoft.Extensions.Localization;
using Schoolar.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Core.Bases
{
	public class ResponseHandler
	{
		private readonly IStringLocalizer<SharedResources> _localizer;
		public ResponseHandler(IStringLocalizer<SharedResources> localizer)
		{
			_localizer = localizer;
		}
		public Response<T> Deleted<T>(string message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.OK,
				Succeeded = true,
				Message = message == null ? _localizer[SharedResourcesKeys.Deleted] : message
			};
		}
		public Response<T> Success<T>(T entity, object Meta = null)
		{
			return new Response<T>()
			{
				Data = entity,
				StatusCode = System.Net.HttpStatusCode.OK,
				Succeeded = true,
				Message = _localizer[SharedResourcesKeys.Success],
				Meta = Meta
			};
		}
		public Response<T> Unauthorized<T>(string message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.Unauthorized,
				Succeeded = true,
				Message = message == null ? _localizer[SharedResourcesKeys.UnAuthorized] : message
			};
		}
		public Response<T> BadRequest<T>(string message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.BadRequest,
				Succeeded = false,
				Message = message == null ? _localizer[SharedResourcesKeys.BadRequest] : message
			};
		}
		public Response<T> UnprocessableEntity<T>(string message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
				Succeeded = false,
				Message = message == null ? _localizer[SharedResourcesKeys.UnprocessableEntity] : message
			};
		}
		public Response<T> NotFound<T>(string message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.NotFound,
				Succeeded = false,
				Message = message == null ? _localizer[SharedResourcesKeys.NotFound] : message
			};
		}
		public Response<T> Created<T>(T entity, object Meta = null)
		{
			return new Response<T>()
			{
				Data = entity,
				StatusCode = System.Net.HttpStatusCode.Created,
				Succeeded = true,
				Message = _localizer[SharedResourcesKeys.Created],
				Meta = Meta
			};
		}
	}
}
