using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

/// <summary>
/// Represents the employment data of the institution.
/// </summary>
namespace Project3_Franko_Fister.Models
{
    public class EmploymentModel
    {
        /// <summary>
        /// Gets or sets the introduction of the employment data.
        /// </summary>
        [JsonProperty("introduction")]
        public Introduction Introduction { get; set; } = new Introduction();

        /// <summary>
        /// Gets or sets the degree statistics of the employment data.
        /// </summary>
        [JsonProperty("degreeStatistics")]
        public DegreeStatistics DegreeStatistics { get; set; } = new DegreeStatistics();

        /// <summary>
        /// Gets or sets the employers of the employment data.
        /// </summary>
        [JsonProperty("employers")]
        public Employers Employers { get; set; } = new Employers();

        /// <summary>
        /// Gets or sets the careers of the employment data.
        /// </summary>
        [JsonProperty("careers")]
        public Careers Careers { get; set; } = new Careers();

        /// <summary>
        /// Gets or sets the coop table of the employment data.
        /// </summary>
        [JsonProperty("coopTable")]
        public CoopTable CoopTable { get; set; } = new CoopTable();

        /// <summary>
        /// Asynchronously retrieves the employment data from the API.
        /// </summary>
        /// <returns>A Task that represents the asynchronous operation. The Task result contains the EmploymentModel retrieved from the API.</returns>
        public static async Task<EmploymentModel?> GetEmploymentAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync("http://ist.rit.edu/api/employment");
                return JsonConvert.DeserializeObject<EmploymentModel>(json);
            }
        }
    }

    /// <summary>
    /// Represents the CoopTable section of the employment data.
    /// </summary>
    public class CoopTable
    {
        /// <summary>
        /// Gets or sets the title of the CoopTable section.
        /// </summary>
        [JsonProperty("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the list of coop information.
        /// </summary>
        [JsonProperty("coopInformation")]
        public List<CoopInformation> CoopInformation { get; set; } = new List<CoopInformation>();
    }

    /// <summary>
    /// Represents the Introduction section of the employment data.
    /// </summary>
    public class Introduction
    {
        /// <summary>
        /// Gets or sets the title of the Introduction section.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the list of content in the Introduction section.
        /// </summary>
        public List<Content>? Content { get; set; }
    }

    /// <summary>
    /// Represents the Content section of the employment data.
    /// </summary>
    public class Content
    {
        /// <summary>
        /// Gets or sets the title of the Content section.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the Content section.
        /// </summary>
        public string? Description { get; set; }
    }

    /// <summary>
    /// Represents the DegreeStatistics section of the employment data.
    /// </summary>
    public class DegreeStatistics
    {
        /// <summary>
        /// Gets or sets the title of the DegreeStatistics section.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the list of statistics in the DegreeStatistics section.
        /// </summary>
        public List<Statistic>? Statistics { get; set; }
    }

    /// <summary>
    /// Represents a specific statistic in the DegreeStatistics section.
    /// </summary>
    public class Statistic
    {
        /// <summary>
        /// Gets or sets the value of the statistic.
        /// </summary>
        public string? Value { get; set; }

        /// <summary>
        /// Gets or sets the description of the statistic.
        /// </summary>
        public string? Description { get; set; }
    }

    /// <summary>
    /// Represents the Employers section of the employment data.
    /// </summary>
    public class Employers
    {
        /// <summary>
        /// Gets or sets the title of the Employers section.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the list of employer names in the Employers section.
        /// </summary>
        public List<string>? EmployerNames { get; set; }
    }

    /// <summary>
    /// Represents the Careers section of the employment data.
    /// </summary>
    public class Careers
    {
        /// <summary>
        /// Gets or sets the title of the Careers section.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the list of career names in the Careers section.
        /// </summary>
        public List<string>? CareerNames { get; set; }
    }

    /// <summary>
    /// Represents a specific coop information in the CoopTable section.
    /// </summary>
    public class CoopInformation
    {
        /// <summary>
        /// Gets or sets the employer of the coop information.
        /// </summary>
        public string? Employer { get; set; }

        /// <summary>
        /// Gets or sets the degree of the coop information.
        /// </summary>
        public string? Degree { get; set; }

        /// <summary>
        /// Gets or sets the city of the coop information.
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Gets or sets the term of the coop information.
        /// </summary>
        public string? Term { get; set; }
    }

    /// <summary>
    /// Represents a specific professional employment information in the Employment section.
    /// </summary>
    public class ProfessionalEmploymentInformation
    {
        /// <summary>
        /// Gets or sets the employer of the professional employment information.
        /// </summary>
        public string? Employer { get; set; }

        /// <summary>
        /// Gets or sets the degree of the professional employment information.
        /// </summary>
        public string? Degree { get; set; }

        /// <summary>
        /// Gets or sets the city of the professional employment information.
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Gets or sets the title of the professional employment information.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the start date of the professional employment information.
        /// </summary>
        public DateTime? StartDate { get; set; }
    }
}