using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json.Linq;
using _20140501Test.Helpers;

namespace _20140501Test.Models
{
	public class Show : iShow
	{
		public Show()
		{
			
		}

		public Show(JToken json)
		{
			// Mandatory Value
			Slug = json.GetValueFromJObject("slug").ToObject<string>();

			// String Values
			Title = (json.JObjectHasValue("title")) ? json.GetValueFromJObject("title").ToObject<string>() : null;
			TvChannel = (json.JObjectHasValue("tvChannel")) ? json.GetValueFromJObject("tvChannel").ToObject<string>() : null;
			Country = (json.JObjectHasValue("country")) ? json.GetValueFromJObject("country").ToObject<string>() : null;
			Description = (json.JObjectHasValue("description")) ? json.GetValueFromJObject("description").ToObject<string>() : null;
			Genre = (json.JObjectHasValue("genre")) ? json.GetValueFromJObject("genre").ToObject<string>() : null;
			Language = (json.JObjectHasValue("language")) ? json.GetValueFromJObject("language").ToObject<string>() : null;
			PrimaryColour = (json.JObjectHasValue("primaryColour")) ? json.GetValueFromJObject("primaryColour").ToObject<string>() : null;

			// Other than string values
			Drm = (json.JObjectHasValue("drm")) ? json.GetValueFromJObject("drm").ToObject<bool>() : false;
			EpisodeCount = (json.JObjectHasValue("episodeCount")) ? json.GetValueFromJObject("episodeCount").ToObject<int>() : 0;

			// Complex values
			Image = (json.JObjectHasValue("image")) ? new Image(json.GetValueFromJObject("image")) : null;
			NextEpisode = (json.JObjectHasValue("nextEpisode")) ? new Episode(json.GetValueFromJObject("nextEpisode")) : null;
			Seasons = (json.JObjectHasValue("seasons")) ? json.GetValueFromJObject("seasons").Select(x => new Show(x)) : null;
		}

		public string Slug { get; set; }
		public string Title { get; set; }
		public string TvChannel { get; set; }
		public string Country { get; set; }
		public string Description { get; set; }
		public bool Drm { get; set; }
		public int EpisodeCount { get; set; }
		public string Genre { get; set; }
		public iImage Image { get; set; }
		public string Language { get; set; }
		public iEpisode NextEpisode { get; set; }
		public string PrimaryColour { get; set; }
		public IEnumerable<iShow> Seasons { get; set; }
	}
}