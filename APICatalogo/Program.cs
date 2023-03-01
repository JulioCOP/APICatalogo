using APICatalogo.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. ConfigureServices()

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Obtenção da string de conexão
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection"); // O nome entre aspas deve ser o mesmo utilizado nas configurações do DB em appsettings

//Registro do EF Core
builder.Services.AddDbContext<AppDbContext>(options => 
                                 options.UseMySql(mySqlConnection,
                                 ServerVersion.AutoDetect(mySqlConnection))); //string de conexão


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
