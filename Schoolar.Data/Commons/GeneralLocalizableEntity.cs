using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Schoolar.Data.Commons
{
	public class GeneralLocalizableEntity
	{
		public string Localize(string nameAr,string name)
		{
			CultureInfo culture = Thread.CurrentThread.CurrentCulture;
			if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
				return nameAr;
			return name;
		}
	}
}
