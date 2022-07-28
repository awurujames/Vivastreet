//using FluentAssertions.Common;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vivastreet.Repository.IRepository;
using Vivastreet.Repository.Repository;
//using System.Configuration;
using Vivastreet_DataAccess;
using Vivastreet_Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ApplicationDbContext>(optionS =>
//            optionS.UseSqlServer(connectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddDefaultTokenProviders().AddDefaultUI()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDbContext<ApplicationDbContext>();

//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//In memory
builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IConditionRepository, ConditionRepository>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IRateRepository, RateRepository>();
builder.Services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IAgeRepository, AgeRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();
// Add hardcoded test data to db on startup
//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

//    var categories = new List<Category> {
//        new Category
//        {
//            Name = "Electrical",
//            DisplayOder = 1,
//            Id = 1,
//        },
//        new Category
//        {
//            Name = "Construction",
//            DisplayOder = 2,
//            Id = 2
//        }
//    };

// Add hardcoded test data to db on startup
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    var categories = new List<Category> {
        new Category
        {
            Name = "Electrical",
            DisplayOder = 1,
            Id = 1,
        },
        new Category
        {
            Name = "Construction",
            DisplayOder = 2,
            Id = 2
        }
    };

    var ages = new List<SelectAge> {
        new SelectAge
        {
            Age = 1,
            Id = 1,
        },
        new SelectAge
        {
            Age = 2,
            Id = 2,
        }
    };

    var conditions = new List<Condition> {
        new Condition
        {
            Name = "Good",
            Id = 1,
        },
        new Condition
        {
            Name = "Bad",
            Id = 2,
        }
    };

    var materials = new List<Material> {
        new Material
        {
            Name = "Good Material",
            Id = 1,
            Durability = "Good",
            Type =  "Normal"
        },
        new Material
        {
            Name = "Bad Material",
            Id = 2,
            Durability = "Bad",
            Type= "Average"
        }
    };

    context.Categories.AddRange(categories);
    context.selectAges.AddRange(ages);
    context.Conditions.AddRange(conditions);
    context.Materials.AddRange(materials);

    context.SaveChanges();
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();        
app.UseAuthorization();


//app.MapControllerRoute(
//    name: "areaRoute",
//    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
           pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
});

app.Run();
