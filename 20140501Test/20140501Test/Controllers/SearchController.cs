using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using _20140501Test.Models;

namespace _20140501Test.Controllers
{
	public class SearchController : ApiController
	{
		[AcceptVerbs("POST")]
		public IEnumerable<iSeries> Get(SearchObject search)
		{
			return new List<Series>();
		}
	}
}
