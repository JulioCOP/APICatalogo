using APICatalogo.Context;
using APICatalogo.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. ConfigureServices()

builder.Services.AddControllers()
      .AddJsonOptions(options =>
         options.JsonSerializerOptions
            .ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Obten��o da string de conex�o
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection"); // O nome entre aspas deve ser o mesmo utilizado nas configura��es do DB em appsettings

//Registro do EF Core
builder.Services.AddDbContext<AppDbContext>(options => 
                                 options.UseMySql(mySqlConnection,
                                 ServerVersion.AutoDetect(mySqlConnection))); //string de conex�o

builder.Services.AddTransient<IMeuServico, MeuServico>();
//AddTransient - tempo de vida -  a instancia do servi�o ser� criada cada vez que for solicitada

var app = builder.Build(); //Configure()

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
