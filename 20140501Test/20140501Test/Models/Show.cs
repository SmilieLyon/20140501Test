using System.Collections.Generic;

namespace _20140501Test.Models
{
	public class Show : iShow
	{
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