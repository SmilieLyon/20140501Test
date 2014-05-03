using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20140501Test.Models
{
	public class SearchObject : ISearchObject
	{
		public IEnumerable<iShow> Payload { get; set; }
		public int Tkip { get; set; }
		public int Take { get; set; }
		public int TotalRecords { get; set; }
	}
}