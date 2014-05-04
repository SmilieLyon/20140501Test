using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20140501Test.Models
{
	public class ResponseObject : IResponseObject
	{
		public IEnumerable<iSeries> response { get; set; }
	}
}