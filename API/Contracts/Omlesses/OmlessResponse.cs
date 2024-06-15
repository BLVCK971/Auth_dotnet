using API.Entities;
namespace API.Contracts;

public class OmlessResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public List<Fan>? Fans { get; set; }
    public List<Video>? Videos { get; set; }
    public List<Don>? Dons { get; set; }
}
