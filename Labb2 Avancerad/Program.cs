using Labb2_Avancerad.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Add services to the container.
builder.Services.AddControllersWithViews();


//Inject DbContext
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors((setup) => setup.AddPolicy("default", (Options =>
{
    Options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
})));


builder.Services.AddScoped<IPersonalRepository, PersonalRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


// lägg till MapControllerRoute?

app.MapControllers();

app.Run();
