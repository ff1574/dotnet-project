/// <summary>
/// Represents the view model for the Error view.
/// </summary>
namespace Project3_Franko_Fister.Models
{
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets the request ID for the error.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether the request ID should be shown.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}