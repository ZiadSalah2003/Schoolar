using MediatR;
using System;
using Schoolar.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schoolar.Core.Features.Students.Queries.Contracts;

namespace Schoolar.Core.Features.Students.Queries.Models
{
    public class GetStudentsQuery : IRequest<List<GetStudentsResponse>>
    {
    }
}
