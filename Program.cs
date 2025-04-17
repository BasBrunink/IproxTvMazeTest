using IproxTvMazeTest;
using IproxTvMazeTest.model;
using IproxTvMazeTest.scraper;
using IproxTvMazeTest.seeder;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Add DB support

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

Console.WriteLine("Starting application...");
Console.WriteLine("Getting shows");

//Seeder to get the shows from the external API
Seeder seeder = new Seeder();
seeder.SeedShows();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
