using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20140501Test.Models
{
	public interface ISearchObject
	{
		IEnumerable<iShow> Payload { get; set; }
		int Tkip { get; set; }
		int Take { get; set; }
		int TotalRecords { get; set; }
	}
}