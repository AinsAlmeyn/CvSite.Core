using System.Text.Json.Serialization;

namespace CvSite.API.Models
{
	public class LoginPreModel
	{
		[JsonPropertyName(nameof(userName))]
		public string userName { get; set; }

        [JsonPropertyName(nameof(password))]
        public string password { get; set; }
	}
}
