
namespace API.Entities;

public class Don
{
    public Guid Id { get; set; }
    public double Amount { get; set; }
    public Guid OmlessId { get; set; }
    public Omless? OmlessGiven { get; set; }
}
