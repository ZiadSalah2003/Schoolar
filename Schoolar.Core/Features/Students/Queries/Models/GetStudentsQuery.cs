using MediatR;
using System;
using Schoolar.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schoolar.Core.Features.Students.Queries.Contracts;
using Schoolar.Core.Bases;

namespace Schoolar.Core.Features.Students.Queries.Models
{
    public class GetStudentsQuery : IRequest<Response<List<GetStudentsResponse>>>
    {
    }
}
