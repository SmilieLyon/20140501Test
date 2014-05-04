using Newtonsoft.Json.Linq;
using _20140501Test.Helpers;

namespace _20140501Test.Models
{
	public class Image : iImage
	{
		public Image()
		{
			
		}

		public Image(JToken json)
		{
			ShowImage = (json.JObjectHasValue("showImage")) ? json.GetValueFromJObject("showImage").ToObject<string>() : null;
		}

		public string ShowImage { get; set; }
	}
}