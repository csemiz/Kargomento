using Microsoft.EntityFrameworkCore;

using AutoMapper.Extensions.ExpressionMapping;
using KargomentoEL.Mappings;
using KargomentoDL;
using KargomentoEL.IdentityModels;
using Microsoft.AspNetCore.Identity;
using KargomentoBL.InterfacesOfManagers;
using KargomentoUI.DefaultData;
using KargomentoBL.ImplementationsOfManagers;
using KargomentoDL.ImplementationsOfRepo;
using KargomentoDL.InterfacesOfRepo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevTest"));

});

builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    // ayarlar eklenecek
    options.Password.RequiredLength = 4;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false; // @ / () [] {} ? : ; karakterler
    options.Password.RequireDigit = false;
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz-_0123456789";
    

}).AddDefaultTokenProviders().AddEntityFrameworkStores<MyContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();


//AutoMapper ayari eklendi.
builder.Services.AddAutoMapper(x =>
{
    x.AddExpressionMapping();
    x.AddProfile(typeof(Maps));
});

//DI yaþam döngüleri

builder.Services.AddScoped<ICityRepo, CityRepo>();
builder.Services.AddScoped<ICityManager, CityManager>();

builder.Services.AddScoped<IDistrictRepo, DistrictRepo>();
builder.Services.AddScoped<IDistrictManager, DistrictManager>();

builder.Services.AddScoped<ICargoStatusRepo, CargoStatusRepo>();
builder.Services.AddScoped<ICargoStatusManager, CargoStatusManager>();
builder.Services.AddScoped<IBranchRepo, BranchRepo>();
builder.Services.AddScoped<IBranchManager, BranchManager>();

builder.Services.AddScoped<IEmployeeBranchRepo, EmployeeBranchRepo>();
builder.Services.AddScoped<IEmployeeBranchManager, EmployeeBranchManager>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<ICustomerManager, CustomerManager>();

builder.Services.AddScoped<ICarrierCallRepo, CarrierCallRepo>();
builder.Services.AddScoped<ICarrierCallManager, CarrierCallManager>();

builder.Services.AddScoped<ICargoRepo, CargoRepo>();
builder.Services.AddScoped<ICargoManager, CargoManager>();

builder.Services.AddScoped<ICargoStatusProcessRepo, CargoStatusProcessRepo>();
builder.Services.AddScoped<ICargoStatusProcessManager, CargoStatusProcessManager>();

builder.Services.AddScoped<ICargoStatusRepo, CargoStatusRepo>();
builder.Services.AddScoped<ICargoStatusManager, CargoStatusManager>();

builder.Services.AddScoped<ICargoPayTypesRepo, CragoPayTypesRepo>();
builder.Services.AddScoped<ICargoPayTypesManager, CargoPayTypesManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


using (var scope = app.Services.CreateScope())
{
    //Resolve ASP .NET Core Identity with DI help
    var userManager = (UserManager<AppUser>?)scope.ServiceProvider.GetService(typeof(UserManager<AppUser>));
    var roleManager = (RoleManager<AppRole>?)scope.ServiceProvider.GetService(typeof(RoleManager<AppRole>));
    // do you things here


    var cargoStatusManager = (ICargoStatusManager?)scope.ServiceProvider.GetService(typeof(ICargoStatusManager));

    var cityManager = (ICityManager?)scope.ServiceProvider.GetService(typeof(ICityManager));

    var districtManager = (IDistrictManager?)scope.ServiceProvider.GetService(typeof(IDistrictManager));

    var employeeBranchManager = (IEmployeeBranchManager?)scope.ServiceProvider.GetService(typeof(IEmployeeBranchManager));

    DataDefault dataDefault = new DataDefault();

    //dataDefault.CheckAndCreateRoles(roleManager);

    //dataDefault.CreateAllCargoStatus(cargoStatusManager);

    //dataDefault.CreateAllCities(cityManager);

    //dataDefault.CreateAllDistricts(districtManager);

    dataDefault.CreateAFewEmployee(userManager,roleManager,employeeBranchManager);

}

app.Run();
