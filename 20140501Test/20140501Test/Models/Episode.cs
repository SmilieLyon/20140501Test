using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using _20140501Test.Helpers;

namespace _20140501Test.Models
{
	public class Episode : iEpisode
	{
		public Episode() { }

		public Episode(JToken json)
		{
			Channel = (json.JObjectHasValue("channel")) ? json.GetValueFromJObject("channel").ToObject<string>() : null;
			ChannelLogo = (json.JObjectHasValue("channelLogo")) ? json.GetValueFromJObject("channelLogo").ToObject<string>() : null;
			Html = (json.JObjectHasValue("html")) ? json.GetValueFromJObject("html").ToObject<string>() : null;
			Url = (json.JObjectHasValue("url")) ? json.GetValueFromJObject("url").ToObject<string>() : null;

			if (json.JObjectHasValue("date"))
			{
				DateTime tempdate;
				if (DateTime.TryParse(json.GetValueFromJObject("date").ToObject<string>(), out tempdate))
				{
					Date = tempdate;
				}
			}
		}

		public string Channel { get; set; }
		public string ChannelLogo { get; set; }
		public DateTime Date { get; set; }
		public string Html { get; set; }
		public string Url { get; set; }
	}
}