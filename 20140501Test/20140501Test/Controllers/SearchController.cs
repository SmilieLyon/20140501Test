using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Newtonsoft.Json.Linq;
using _20140501Test.Business;
using _20140501Test.Helpers;
using _20140501Test.Models;

namespace _20140501Test.Controllers
{
	public class SearchController : ApiController
	{
		[System.Web.Http.AcceptVerbs("POST")]
		public ResponseObject Post(HttpRequestMessage request)
		{
			
			try
			{
				var jsonContent = request.Content.ReadAsStringAsync().Result;
				return new ResponseObject {response = SearchRecordsFromJson(jsonContent)};
			}
			catch (Exception)
			{
				throw new HttpResponseException(
						new HttpResponseMessage(HttpStatusCode.BadRequest)
						{
							Content = new StringContent("{\"Error\": \"Could not decode request: JSON parsing failed\"}", Encoding.UTF8, "application/json"),
							ReasonPhrase = "Error, Could not decode request: JSON parsing failed"
						});
			}
		}

		public List<Series> SearchRecordsFromJson(string jsonContent)
		{
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
					image = shows.Image.ShowImage,
					slug = shows.Slug,
					title = shows.Title
				};
			return retShows.Skip(search.Skip).Take(search.Take).ToList();
		}
	}
}
