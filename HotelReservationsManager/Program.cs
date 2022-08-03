using HotelReservationsManager.Data;
using HotelReservationsManager.Data.Entities;
using HotelReservationsManager.Repositories;
using HotelReservationsManager.Repositories.Rooms;
using HotelReservationsManager.Seeding;
using HotelReservationsManager.Services;
using HotelReservationsManager.Services.Rooms;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using HotelReservationsManager.Dtos;
using AutoMapper;
using HotelReservationsManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddMvc();

builder.Services.AddScoped<ISeeder, Seeder>();
//builder.Services.AddTransient(typeof(IBaseRepository<>),typeof(BaseRepository<>));
builder.Services.AddTransient<IRoomsRepository, RoomsRepository>();

//builder.Services.AddTransient<IBaseService<BaseDto>,BaseService<BaseDto>>();
builder.Services.AddTransient<IRoomsService, RoomsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

SeedDatabase();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

void SeedDatabase() 
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<ISeeder>();
        dbInitializer.PopulateDb().GetAwaiter().GetResult();
    }
}
//void ConfigureContainer(ContainerBuilder builder)
//{
//    builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(BaseRepository<,>)))
//           .Where(t => t.Name.EndsWith("Repository"))
//           .InstancePerLifetimeScope()
//           .AsImplementedInterfaces();

//    builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(BaseService<>)))
//           .Where(t => t.Name.EndsWith("Service"))
//           .InstancePerLifetimeScope()
//           .AsImplementedInterfaces();    
//}
