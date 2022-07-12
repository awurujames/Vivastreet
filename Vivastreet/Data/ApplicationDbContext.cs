using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Vivastreet.Models;

namespace Vivastreet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> option) : base(option)
        {
              
        }
        
        public DbSet<Advertisement>? Advertisements { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Condition>? Conditions { get; set; }
        public DbSet<Language>? Langauges { get; set; }
        public DbSet<Material>? Materials { get; set; }
        public DbSet<Rate>? Rates { get; set; }
        public DbSet<SelectAge>? selectAges { get; set; }
        public DbSet<ServiceOffered>? ServiceOffereds { get; set; }
        public DbSet<City>? Citys { get; set; }

    }
}
