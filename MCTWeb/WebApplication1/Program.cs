using Microsoft.AspNetCore.SpaServices.AngularCli;
using System.Data.SqlTypes;
using WebApplication1.Extensions;
using WebApplication1.Extensions.Factory;
using WebApplication1.Extensions.Factory.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<CollectionGenerationService>();
builder.Services.AddScoped<INumberFactory, NumberFactory>();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.Run();