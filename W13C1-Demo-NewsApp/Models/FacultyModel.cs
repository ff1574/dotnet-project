using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Project3_Franko_Fister.Models
{
    /// <summary>
    /// Represents a faculty member.
    /// </summary>
    public class Faculty
    {
        /// <summary>
        /// Gets or sets the username of the faculty member.
        /// </summary>
        [JsonProperty("username")]
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the name of the faculty member.
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the tagline of the faculty member.
        /// </summary>
        [JsonProperty("tagline")]
        public string? Tagline { get; set; }

        /// <summary>
        /// Gets or sets the image path of the faculty member.
        /// </summary>
        [JsonProperty("imagePath")]
        public string? ImagePath { get; set; }

        /// <summary>
        /// Gets or sets the title of the faculty member.
        /// </summary>
        [JsonProperty("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the interest area of the faculty member.
        /// </summary>
        [JsonProperty("interestArea")]
        public string? InterestArea { get; set; }

        /// <summary>
        /// Gets or sets the office of the faculty member.
        /// </summary>
        [JsonProperty("office")]
        public string? Office { get; set; }

        /// <summary>
        /// Gets or sets the website of the faculty member.
        /// </summary>
        [JsonProperty("website")]
        public string? Website { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the faculty member.
        /// </summary>
        [JsonProperty("phone")]
        public string? Phone { get; set; }

        /// <summary>
        /// Gets or sets the email of the faculty member.
        /// </summary>
        [JsonProperty("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the Twitter handle of the faculty member.
        /// </summary>
        [JsonProperty("twitter")]
        public string? Twitter { get; set; }

        /// <summary>
        /// Gets or sets the Facebook page of the faculty member.
        /// </summary>
        [JsonProperty("facebook")]
        public string? Facebook { get; set; }
    }

    /// <summary>
    /// Represents a collection of faculty members.
    /// </summary>
    public class FacultyCollection
    {
        /// <summary>
        /// Gets or sets the list of faculty members.
        /// </summary>
        [JsonProperty("faculty")]
        public List<Faculty> Faculty { get; set; } = new List<Faculty>();
    }

    /// <summary>
    /// Provides methods to retrieve faculty information.
    /// </summary>
    public static class FacultyService
    {
        /// <summary>
        /// Asynchronously retrieves the faculty members.
        /// </summary>
        /// <returns>A Task that represents the asynchronous operation. The Task result contains the FacultyCollection retrieved from the API.</returns>
        public static async Task<FacultyCollection> GetFacultyAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync("http://ist.rit.edu/api/people/faculty");
                return JsonConvert.DeserializeObject<FacultyCollection?>(json) ?? new FacultyCollection();
            }
        }
    }
}