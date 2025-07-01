namespace Versta.Landing.Api.Common.Errors;

public class ValidationErrorResponse
{
    public int Status { get; set; }
    public string Title { get; set; } = default!;
    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    public string TraceId { get; set; } = default!;
}