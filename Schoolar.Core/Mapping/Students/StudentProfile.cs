﻿using AutoMapper;
using Schoolar.Core.Features.Students.Queries.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schoolar.Data.Entities;

namespace Schoolar.Core.Mapping.Students
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentsMapping();
		}
    }
}