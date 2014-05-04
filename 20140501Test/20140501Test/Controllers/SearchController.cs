using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Newtonsoft.Json.Linq;
using _20140501Test.Business;
using _20140501Test.Helpers;
using _20140501Test.Models;

namespace _20140501Test.Controllers
{
	public class SearchController : ApiController
	{
		[AcceptVerbs("POST")]
		public IEnumerable<iSeries> Post(HttpRequestMessage request)
		{
			try
			{
				var jsonContent = request.Content.ReadAsStringAsync().Result;
				var obj = JObject.Parse(jsonContent);
				var search = new SearchObject
				{
					Skip = obj.GetValueFromJObject("skip").ToObject<int>(),
					Take = obj.GetValueFromJObject("take").ToObject<int>(),
					TotalRecords = obj.GetValueFromJObject("totalRecords").ToObject<int>()
				};
				var list = new List<iShow>();
				foreach (var show in obj["payload"])
				{
					var newShow = new Show(show);
					list.Add(newShow);
				}
				var retShows = 
					from shows in
						(new SearchBusiness()).FilterShowsByDrmAndEpisodeCount(list)
					select new Series()
					{
						Image = shows.Image.ShowImage,
						Slug = shows.Slug,
						Title = shows.Title
					};
				return retShows.Skip(search.Skip).Take(search.Take);
			}
			catch (Exception exception)
			{
				request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error, JSON parsing failed:");
			}
			
			return null;
		}
	}
}
