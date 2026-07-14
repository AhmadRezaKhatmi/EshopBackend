using Eshop.Core.Security;
using Eshop.Core.Services.Implementations;
using Eshop.Core.Services.Interfaces;
using Eshop.Core.Utilities.Extensions.Connection;
using Eshop.Data.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



#region Add DbContext

builder.Services.AddApplicationDbContext(builder.Configuration);

#endregion



#region Add GenericRepository

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

#endregion


#region Add Application Services

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPasswordHelper, PasswordHelper>();
#endregion


#region Add Authentication

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:44381",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("EshopJwtBearerSymmetricSecurityKey"))
        };
    });

#endregion


#region Add CORS

builder.Services.AddCors(options =>
 options.AddPolicy("EnableCors", builder =>
 {
     builder.WithOrigins("http://localhost:4200")
         .AllowAnyHeader()
         .AllowAnyMethod()
         .AllowCredentials()
         .Build();
 }));




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

app.UseStaticFiles();

app.UseCors("EnableCors");

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Users}/{id?}")
    .WithStaticAssets();


app.Run();
