using System.Diagnostics;

namespace WebHealthStatus.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorViewModel> _logger;

        public ErrorViewModel(ILogger<ErrorViewModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            /*RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;*/
        }
    }
}
