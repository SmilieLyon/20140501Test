using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _20140501Test.Models;

namespace _20140501Test.Business
{
	public class SearchBusiness
	{
		public IEnumerable<iShow> FilterShowsByDrmAndEpisodeCount(IEnumerable<iShow> shows)
		{
			return
				from s in shows
				where s.Drm == true &&
				      s.EpisodeCount > 0
				select s;
		}
	}
}