using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Project3_Franko_Fister
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Represents the degrees offered by the institution.
    /// </summary>
    public partial class Degrees
    {
        /// <summary>
        /// Gets or sets the list of undergraduate degrees.
        /// </summary>
        [JsonProperty("undergraduate")]
        public List<Graduate> Undergraduate { get; set; } = new List<Graduate>();

        /// <summary>
        /// Gets or sets the list of graduate degrees.
        /// </summary>
        [JsonProperty("graduate")]
        public List<Graduate> Graduate { get; set; } = new List<Graduate>();
    }

    /// <summary>
    /// Represents a specific degree offered by the institution.
    /// </summary>
    public partial class Graduate
    {
        /// <summary>
        /// Gets or sets the name of the degree.
        /// </summary>
        [JsonProperty("degreeName")]
        public string? DegreeName { get; set; }

        /// <summary>
        /// Gets or sets the title of the degree.
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the degree.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the list of concentrations for the degree.
        /// </summary>
        [JsonProperty("concentrations", NullValueHandling = NullValueHandling.Ignore)]
        public List<string>? Concentrations { get; set; }

        /// <summary>
        /// Gets or sets the list of available certificates for the degree.
        /// </summary>
        [JsonProperty("availableCertificates", NullValueHandling = NullValueHandling.Ignore)]
        public List<string>? AvailableCertificates { get; set; }
    }

    /// <summary>
    /// Provides methods to retrieve degree information.
    /// </summary>
    public static class DegreesService
    {
        /// <summary>
        /// Asynchronously retrieves the degrees offered by the institution.
        /// </summary>
        /// <returns>A Task that represents the asynchronous operation. The Task result contains the Degrees retrieved from the API.</returns>
        public static async Task<Degrees> GetDegreesAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync("http://ist.rit.edu/api/degrees");
                return JsonConvert.DeserializeObject<Degrees?>(json) ?? new Degrees();
            }
        }
    }
}