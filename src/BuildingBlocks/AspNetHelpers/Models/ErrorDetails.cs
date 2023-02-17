using System.Text.Json;

namespace WebApplicationHelpers.Models;

internal class ErrorDetails
{
    public string Detail { get; init; }
    public int StatusCode { get; init; }
    public string Title { get; init; }
    public string Type { get; init; }

    public override string ToString() => JsonSerializer.Serialize(this);
}
