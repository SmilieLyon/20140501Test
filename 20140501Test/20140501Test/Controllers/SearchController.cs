using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Newtonsoft.Json.Linq;
using _20140501Test.Helpers;
using _20140501Test.Models;

namespace _20140501Test.Controllers
{
	public class SearchController : ApiController
	{
		[AcceptVerbs("POST")]
		public IEnumerable<iSeries> Post(HttpRequestMessage request)
		{
			var jsonContent = request.Content.ReadAsStringAsync().Result;
			var obj = JObject.Parse(jsonContent);
			try
			{
				var search = new SearchObject
				{
					Skip = obj.GetValueFromJObject("skip").ToObject<int>(),
					Take = obj.GetValueFromJObject("take").ToObject<int>(),
					TotalRecords = obj.GetValueFromJObject("totalRecords").ToObject<int>()
				};
				var list = new List<iShow>();
				foreach (var show in obj["payload"])
				{
					var newShow = new Show();
					newShow.Slug = show.GetValueFromJObject("slug").ToObject<string>();
					newShow.Title = show.GetValueFromJObject("title").ToObject<string>();
					newShow.TvChannel = show.GetValueFromJObject("tvChannel").ToObject<string>();

					newShow.Country = (show.JObjectHasValue("country")) ? show.GetValueFromJObject("country").ToObject<string>() : null;
					newShow.Description = (show.JObjectHasValue("description")) ? show.GetValueFromJObject("description").ToObject<string>() : null;
					newShow.Genre = (show.JObjectHasValue("genre")) ? show.GetValueFromJObject("genre").ToObject<string>() : null;
					newShow.Language = (show.JObjectHasValue("language")) ? show.GetValueFromJObject("language").ToObject<string>() : null;
					newShow.PrimaryColour = (show.JObjectHasValue("primaryColour")) ? show.GetValueFromJObject("primaryColour").ToObject<string>() : null;

					newShow.Drm = (show.JObjectHasValue("drm")) ? show.GetValueFromJObject("drm").ToObject<bool>() : false;
					newShow.EpisodeCount = (show.JObjectHasValue("episodeCount")) ? show.GetValueFromJObject("episodeCount").ToObject<int>() : 0;

					if (string.IsNullOrWhiteSpace(newShow.Slug))
					{
						throw new MissingFieldException("slug");
					}
					if (string.IsNullOrWhiteSpace(newShow.Title))
					{
						throw new MissingFieldException("title");
					}
					if (string.IsNullOrWhiteSpace(newShow.TvChannel))
					{
						throw new MissingFieldException("tvChannel");
					}
					list.Add(newShow);
				}
			}
			catch (Exception exception)
			{
				request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error, JSON parsing failed:" + exception.Message);
				throw;
			}
			
			return null;
		}
	}
}
