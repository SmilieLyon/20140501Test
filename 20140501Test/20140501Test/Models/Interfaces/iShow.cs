using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace _20140501Test.Models
{
	public interface iShow
	{
		string Slug { get; set; }
		string Title { get; set; }
		string TvChannel { get; set; }
		string Country { get; set; }
		string Description { get; set; }
		bool Drm { get; set; }
		int EpisodeCount { get; set; }
		string Genre { get; set; }
		iImage Image { get; set; }
		string Language { get; set; }
		iEpisode NextEpisode { get; set; }
		string PrimaryColour { get; set; }
		IEnumerable<iShow> Seasons { get; set; }
	}
}