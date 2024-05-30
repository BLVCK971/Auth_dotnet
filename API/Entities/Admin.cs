
using API.Identity;

namespace API.Entities;

public class Admin : MyUser
{
    public IEnumerable<Mediator>? Mediators { get; set; }
}
