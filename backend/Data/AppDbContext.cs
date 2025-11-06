using ItServiceDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace ItServiceDashboard.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Server> Servers => Set<Server>();
    public DbSet<Ticket> Tickets => Set<Ticket>();
}
