using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace _20140501Test.Helpers
{
	public static class ProcessingHelper
	{
		public static object GetValueFromJObject(JToken token, string variable)
		{
			var theVariable = token[variable];
			return theVariable ?? null;
		}
	}
}
