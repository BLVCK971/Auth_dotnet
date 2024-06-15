using API.Entities;
namespace API.Contracts;

public class VideoResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public string Url { get; set; } = String.Empty;
    public Guid OmlessId { get; set; }
    public Omless? OmlessGiven { get; set; }
}
