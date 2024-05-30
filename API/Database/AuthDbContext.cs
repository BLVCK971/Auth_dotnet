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
    public DbSet<Don> Don { get; set; }
    public DbSet<Fan> Fan { get; set; }
    public DbSet<Mediator> Mediator { get; set; }
    public DbSet<Omless> Omless { get; set; }
    public DbSet<Video> Video { get; set; }
}
