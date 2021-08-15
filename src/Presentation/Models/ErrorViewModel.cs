namespace Presentation.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        
        public string Message { get; set; }

        public string Trace { get; set; }
    }
}
