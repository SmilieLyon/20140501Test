using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace _20140501Test.Models
{
	public class Show : iShow
	{
		public Show()
		{
			
		}

		public Show(string json)
		{
			var obj = JObject.Parse(json);
			var payload = obj["payload"];
			Slug = (string) payload["slug"];
			Title = (string) payload["Title"]; 
			TvChannel = (string) payload["TvChannel"]; 
			Country = (string) payload["Country"]; 
			Description = (string) payload["Description"]; 
			Drm = (bool) payload["Drm"]; 
			EpisodeCount = (int) payload["EpisodeCount"]; 
			Genre = (string) payload["Genre"]; 
			Language = (string) payload["Language"]; 
			PrimaryColour = (string) payload["PrimaryColour"]; 
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