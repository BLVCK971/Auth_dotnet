namespace API.Entities;

public class Association
{
	public int Id { get; set; }
    public IEnumerable<Mediator>? Mediators { get; set; }
    public IEnumerable<Omless>? OmlessResponsible { get; set; }
}
