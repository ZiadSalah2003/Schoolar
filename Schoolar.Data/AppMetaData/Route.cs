using System;
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
			public const string CreateStudent = Prefix + "/create";
			public const string EditStudent = Prefix + "/update";
			public const string DeleteStudent = Prefix + SingleRoute;
			public const string Paginated = Prefix + "/Paginated";
		}
		public static class DepartmentRouting
		{
			public const string Prefix = Rule + "Department";
			public const string GetByID = Prefix + "/Id";
			public const string GetDepartmentStudentsCount = Prefix + "/Department-Students-Count";
			public const string GetDepartmentStudentsCountById = Prefix + "/Department-Students-Count-ById/{id}";
		}
	}
}
