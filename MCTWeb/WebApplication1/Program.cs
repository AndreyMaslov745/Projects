using System.Data.SqlTypes;
using WebApplication1.Extensions;
using WebApplication1.Extensions.Factory;
using WebApplication1.Extensions.Factory.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CollectionGenerationService>();
builder.Services.AddScoped<INumberFactory, NumberFactory>();
var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Default",
        pattern: "{controller=Home}/{action=Index}");
});
app.Run();