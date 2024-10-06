﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Data.AppMetaData
{
	public static class Route
	{
		public const string SingleRoute = "{id}";

		public const string root = "api";
		public const string version = "v1";
		public const string Rule = root + "/" + version + "/";
		
		public static class StudentRoute
		{
			public const string Prefix = Rule + "Student";
			public const string GetStudents = Prefix +"/all-student";
			public const string GetStudentById = Prefix + SingleRoute;
			public const string CreateStudent = Prefix + "/Create";
		}
	}
}