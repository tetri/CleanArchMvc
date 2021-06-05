using CleanArchMvc.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            //builder.ApplyConfiguration(new CategoryConfiguration()); //não é necessário fazer um por um por conta da linha acima ;)
            //builder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
