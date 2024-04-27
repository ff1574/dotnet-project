using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

/// <summary>
/// Represents the news data of the institution.
/// </summary>
namespace Project3_Franko_Fister.Models
{
    public class NewsModel
    {
        /// <summary>
        /// Gets or sets the date of the news.
        /// </summary>
        public string? Date { get; set; }

        /// <summary>
        /// Gets or sets the title of the news.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the news.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Asynchronously retrieves the news data from the API.
        /// </summary>
        /// <returns>A Task that represents the asynchronous operation. The Task result contains the NewsViewModel retrieved from the API.</returns>
        public static async Task<NewsViewModel?> GetViewModelAsync()
        {
            string json = await new HttpClient().GetStringAsync(
                "http://ist.rit.edu/api/news");
            return JsonConvert.DeserializeObject<NewsViewModel>(json);
        }
    }
}