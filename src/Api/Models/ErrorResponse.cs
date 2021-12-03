namespace Api.Models
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ErrorResponse(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
    }
}
