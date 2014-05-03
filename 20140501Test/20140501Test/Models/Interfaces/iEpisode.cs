using System;
using System.Collections;
using System.Collections.Generic;

namespace _20140501Test.Models
{
	public interface iEpisode
	{   
		string Channel { get; set; }
		string ChannelLogo { get; set; }
		DateTime Date { get; set; }
		string Html { get; set; }
		string Url {get;set;}
	}
}