using MediatR;
using Microsoft.EntityFrameworkCore;
using Product_easa_Database.SQLConnection;
using Product_easaWebApi.Middleware;
using Product_easaWebApi.Util;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
Assembly assembly = Assembly.GetExecutingAssembly();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
builder.Services.AddTransient<Mediator>();
builder.Services.AddCommendTransients();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

builder.Services
   .AddDbContext<ProductEasaDbContext>(options =>
   {
       string? connectionString = builder.Configuration.GetConnectionString("DefaultSQL");
       options.UseSqlServer(connectionString);
   });
var app = builder.Build();
app.UseCors(cors => cors
              .AllowAnyMethod()
              .AllowAnyHeader()
              .SetIsOriginAllowed(origin => true) // allow any origin
              .AllowCredentials()); // allow credentials
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseResponseCaching();
app.UseRouting();
app.UseAuthentication();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
