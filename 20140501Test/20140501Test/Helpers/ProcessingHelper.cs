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
		public static bool JObjectHasValue(this JToken token, string variable)
		{
			var theVariable = token[variable];
			return theVariable != null;
		}

		public static JToken GetValueFromJObject(this JToken token, string variable)
		{
			var theVariable = token[variable];
			if (theVariable == null)
			{
				throw new MissingFieldException(variable + " is missing");
			}
			return theVariable;
		}
	}
}
