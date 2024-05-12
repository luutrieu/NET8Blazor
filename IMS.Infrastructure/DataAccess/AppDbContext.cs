using IMS.Application.Extension.Identity;
using IMS.Domain.Entites.ActivityTracker;
using IMS.Domain.Entites.Orders;
using IMS.Domain.Entites.Products;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IMS.Infrastructure.DataAccess
{
    public class AppDbContext(DbContextOptions<AppDbContext> options):
        IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Tracker> ActivityTracker { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
