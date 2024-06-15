namespace API.Contracts;

public class CreateVideoRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Url { get; set; } = String.Empty;
    public Guid OmlessId { get; set; }
}
