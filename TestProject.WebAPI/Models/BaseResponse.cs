namespace TestProject.WebAPI.ViewModels
{
    /// <summary>
    /// Base Response Class.
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// Success.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Error message if any.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}