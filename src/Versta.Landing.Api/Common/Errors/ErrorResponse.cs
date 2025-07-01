namespace Versta.Landing.Api.Common.Errors;

public class ErrorResponse
{
    public int Status { get; set; }
    public string Title { get; set; } = default!;
    public string TraceId { get; set; } = default!;
}