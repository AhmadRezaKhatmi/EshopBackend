using Eshop.Core.Services.Implementations;
using Eshop.Core.Services.Interfaces;
using Eshop.Core.Utilities.Extensions.Connection;
using Eshop.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



#region Add DbContext

builder.Services.AddApplicationDbContext(builder.Configuration);

#endregion



#region Add GenericRepository

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

#endregion


#region Application Services

builder.Services.AddScoped<IUserService, UserService>();

#endregion




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Users}/{id?}")
    .WithStaticAssets();


app.Run();
