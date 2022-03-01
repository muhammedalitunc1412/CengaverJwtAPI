using JwtAPI.Core.Domain;
using JwtAPI.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JwtAPI.Persistance.Context
{
    public class JwtContext : DbContext
    {
        public JwtContext(DbContextOptions<JwtContext> options) : base(options)
        {

        }
        public DbSet<Product> Products
        {
            get
            {
                return this.Set<Product>();
            }
        }
        public DbSet<Category> Categories=>this.Set<Category>();
       
        public DbSet<AppUser> AppUsers=>this.Set<AppUser>();
        
        public DbSet<AppRole> AppRoles=>this.Set<AppRole>();
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
