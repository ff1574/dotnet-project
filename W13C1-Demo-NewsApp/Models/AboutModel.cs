using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

/// <summary>
/// Represents the About section of the website.
/// </summary>
namespace Project3_Franko_Fister.Models
{
    public class AboutModel
    {
        /// <summary>
        /// Gets or sets the title of the About section.
        /// </summary>
        [JsonProperty("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the About section.
        /// </summary>
        [JsonProperty("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the quote displayed in the About section.
        /// </summary>
        [JsonProperty("quote")]
        public string? Quote { get; set; }

        /// <summary>
        /// Gets or sets the author of the quote displayed in the About section.
        /// </summary>
        [JsonProperty("quoteAuthor")]
        public string? QuoteAuthor { get; set; }

        /// <summary>
        /// Asynchronously retrieves the AboutModel from the API.
        /// </summary>
        /// <returns>A Task that represents the asynchronous operation. The Task result contains the AboutModel retrieved from the API.</returns>
        public static async Task<AboutModel?> GetModelAsync()
        {
            string json = await new HttpClient().GetStringAsync(
                "http://ist.rit.edu/api/about");
            return JsonConvert.DeserializeObject<AboutModel>(json);
        }
    }
}