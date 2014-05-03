﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace _20140501Test.Models
{
	public class Episode : iEpisode
	{
		public string Channel { get; set; }
		public string ChannelLogo { get; set; }
		public DateTime Date { get; set; }
		public string Html { get; set; }
		public string Url { get; set; }
	}
}