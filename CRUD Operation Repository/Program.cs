using CRUD_Operation_Repository.Data;
using CRUD_Operation_Repository.Mapping;
using CRUD_Operation_Repository.Services.Unit_Of_Work;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection_string = builder.Configuration.GetConnectionString("connection");
builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(connection_string));
builder.Services.AddTransient<IunitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
