using Microsoft.EntityFrameworkCore;
using ProfProject.Data.Contexts;
using ProfProject.Data.Repositorios;
using ProfProject.Data.UoW;
using ProfProject.Interfaces.Repositorios;
using ProfProject.Interfaces.UoW;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<SQLContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IProfessorRepositorio, ProfessorRepositorio>();
builder.Services.AddScoped<IMateriaRepositorio, MateriaRepositorio>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// migrate
var services = builder.Services.BuildServiceProvider();
var sqlContext = services.GetService<SQLContext>();
sqlContext.Database.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
