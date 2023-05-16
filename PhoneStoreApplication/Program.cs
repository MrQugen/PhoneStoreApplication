using Microsoft.EntityFrameworkCore;
using PhoneStoreApplication.Data;
using PhoneStoreApplication.Data.Repository;
using PhoneStoreApplication.MocksData;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPhoneMock, PhoneMock>();
builder.Services.AddSingleton<IBrandMock, BrandMock>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Add services to the container.
builder.Services.AddControllersWithViews()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.WriteIndented = true;
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        }); ;

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.EnableSensitiveDataLogging();
    options.UseSqlServer(
       builder.Configuration.GetConnectionString("DefaultConnection"),

       sqlServerOptionsAction: sqlOptions =>
       {
           sqlOptions.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName);
       });
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseSession();

using (var scope = app.Services.CreateScope())
{
    await DataInitializer.InitializeAsync(scope.ServiceProvider);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Phone}/{action=Index}/{brandId?}");

app.Run();
