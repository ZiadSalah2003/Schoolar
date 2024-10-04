using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Core.Bases
{
	public class Response<T>
	{
		public Response()
		{
		}
		public Response(T data, string message = null)
		{
			Succeeded = true;
			Message = message;
			Data = data;

		}
		public Response(string message, bool succeeded)
		{
			Succeeded = succeeded;
			Message = message;
		}
		public HttpStatusCode StatusCode { get; set; }
		public Object Meta { get; set; }
		public bool Succeeded { get; set; }
		public string Message { get; set; }
		public List<T> Erros { get; set; }
		public T Data { get; set; }
	}
}
