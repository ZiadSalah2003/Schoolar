//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Schoolar.Data.Commons
//{
//	public class LocalizableEntity
//	{
//        public string NameAr { get; set; }
//        public string Name { get; set; }

//        public string GetLocalizedName()
//		{
//			CultureInfo culture = Thread.CurrentThread.CurrentCulture;
//			if(culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
//				return NameAr;
//			return Name;
//		}
//	}
//}
