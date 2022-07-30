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

//Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(optionS =>
            optionS.UseSqlServer(connectionString));

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

//    var ages = new List<SelectAge> {
//        new SelectAge
//        {
//            Age = 1,
//            Id = 1,
//        },
//        new SelectAge
//        {
//            Age = 2,
//            Id = 2,
//        }
//    };

//    var conditions = new List<Condition> {
//        new Condition
//        {
//            Name = "Good",
//            Id = 1,
//        },
//        new Condition
//        {
//            Name = "Bad",
//            Id = 2,
//        }
//    };

//    var cities = new List<City> {
//        new City
//        {
//            CityName = "Lagos",
//            Id = 1,
//        },
//        new City
//        {
//            CityName = "Abuja",
//            Id = 2,
//        }
//    };

//    var materials = new List<Material> {
//        new Material
//        {
//            Name = "Good Material",
//            Id = 1,
//            Durability = "Good",
//            Type =  "Normal"
//        },
//        new Material
//        {
//            Name = "Bad Material",
//            Id = 2,
//            Durability = "Bad",
//            Type= "Average"
//        }
//    };

//    var adverts = new List<Advertisement> {
//        new Advertisement
//        {
//            Title = "Blender UK",
//            Id = 1,
//            PostCode = "101221",
//            English =  true,
//            CategoryId = 1,
//            Description = "This is a dummy advert",
//            MaterialId = 1,
//            SelectAgeId = 1,
//            CityId = 1,
//            ConditionId = 1,
//            DeliveryServiceFee = "100",
//            IsDeliveryService = true,
//            PickUpServiceFee = "100",
//            IsPickUpService = true,
//            InstallationServiceFee = "1000",
//            IsInstallationService = true,
//            PhoneNumber = "08123789939",
//            ShowPhoneNumber = true,
//            EmailAddress = "testingviva@gmail.com",
//            Image = "/images/productImages/6935f999-b29c-40df-a175-1b63f11c342e.jpeg"
//        },
//        new Advertisement
//        {
//            Title = "Iron UK",
//            Id = 2,
//            PostCode = "101222",
//            English =  true,
//            CategoryId = 2,
//            Description = "This is a dummy advert",
//            MaterialId = 2,
//            SelectAgeId = 2,
//            CityId = 2,
//            ConditionId = 2,
//            DeliveryServiceFee = "10",
//            IsDeliveryService = true,
//            PickUpServiceFee = "10",
//            IsPickUpService = true,
//            InstallationServiceFee = "100",
//            IsInstallationService = true,
//            PhoneNumber = "09078789939",
//            ShowPhoneNumber = false,
//            EmailAddress = "devtestingviva@gmail.com",
//            Image = "/images/productImages/6935f999-b29c-40df-a175-1b63f11c342e.jpeg"
//        },
//        new Advertisement
//        {
//            Title = "Computer UK",
//            Id = 3,
//            PostCode = "101224",
//            English =  true,
//            CategoryId = 1,
//            Description = "This is a dummy advert",
//            MaterialId = 1,
//            SelectAgeId = 1,
//            CityId = 1,
//            ConditionId = 1,
//            DeliveryServiceFee = "1000",
//            IsDeliveryService = true,
//            PickUpServiceFee = "100",
//            IsPickUpService = true,
//            InstallationServiceFee = "10000",
//            IsInstallationService = true,
//            PhoneNumber = "08126789939",
//            ShowPhoneNumber = true,
//            EmailAddress = "testingvivastreet@gmail.com",
//            Image = "/images/productImages/6935f999-b29c-40df-a175-1b63f11c342e.jpeg"
//        },
//        new Advertisement
//        {
//            Title = "Car UK",
//            Id = 4,
//            PostCode = "101228",
//            English =  true,
//            CategoryId = 1,
//            Description = "This is a dummy advert",
//            MaterialId = 1,
//            SelectAgeId = 1,
//            CityId = 1,
//            ConditionId = 1,
//            DeliveryServiceFee = "100",
//            IsDeliveryService = true,
//            PickUpServiceFee = "100",
//            IsPickUpService = true,
//            InstallationServiceFee = "1000",
//            IsInstallationService = true,
//            PhoneNumber = "08123780039",
//            ShowPhoneNumber = true,
//            EmailAddress = "alltestingviva@gmail.com",
//            Image = "/images/productImages/6935f999-b29c-40df-a175-1b63f11c342e.jpeg"
//        },
//    };

//    context.Categories.AddRange(categories);
//    context.selectAges.AddRange(ages);
//    context.Conditions.AddRange(conditions);
//    context.Materials.AddRange(materials);
//    context.Advertisements.AddRange(adverts);
//    context.Citys.AddRange(cities);

//    context.SaveChanges();
//}
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


app.MapControllerRoute(
    name: "areaRoute",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
           pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
});

app.Run();
