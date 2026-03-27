using Microsoft.OpenApi;
using MySqlConnector;
using System.Data;
using Usuarios.API.Mapping;
using Usuarios.API.Repository;
using Usuarios.API.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Usuários",
        Version = "v1",
        Description = "Este projeto tem como objetivo disponibilizar endpoints com retorno de dados referentes a Usuários, sendo informações de nome, data de nascimento e CPF.",
        Contact = new OpenApiContact
        {
            Name = "Guilherme Souza Nogueira",
            Email = "guilherme10.nogueira@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/guilherme-nogueira-2823b4285")
        }
    });
});

builder.Services.AddScoped<IDbConnection>(sp =>
    new MySqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<UsuarioMapping>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();