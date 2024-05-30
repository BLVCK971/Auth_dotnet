
using API.Identity;

namespace API.Entities;

public class Fan : MyUser
{
    public List<Don>? DonsFaits { get; set; }
}
