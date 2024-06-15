using API.Identity;
using API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Database;

class AuthDbContext : IdentityDbContext<MyUser>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options) { }

    public DbSet<Admin> Admins { get; set; }
    public DbSet<Association> Associations { get; set; }
    public DbSet<Don> Dons { get; set; }
    public DbSet<Fan> Fans { get; set; }
    public DbSet<Mediator> Mediators { get; set; }
    public DbSet<Omless> Omlesses { get; set; }
    public DbSet<Video> Videos { get; set; }
}
