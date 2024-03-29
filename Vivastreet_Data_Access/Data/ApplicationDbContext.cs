﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Vivastreet.Models;
using Vivastreet_Models;
using Vivastreet_Models.ViewModel;

namespace Vivastreet_DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }
        //private readonly IConfiguration _config;

        //public ApplicationDbContext(IConfiguration configuration)
        //{
        //    _config = configuration;
        //}

        public DbSet<Advertisement>? Advertisements { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Condition>? Conditions { get; set; }
        public DbSet<Language>? Langauges { get; set; }
        public DbSet<Material>? Materials { get; set; }
        public DbSet<Rate>? Rates { get; set; }
        public DbSet<SelectAge>? selectAges { get; set; }
        public DbSet<ServiceOffered>? ServiceOffereds { get; set; }
        public DbSet<City>? Citys { get; set; }
        public DbSet<ApplicationUser>? ApplicationUsers { get; set; }
        //public DbSet<Pager>? Pagers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseInMemoryDatabase("TestDb");
        //}
    }

    
    
}
