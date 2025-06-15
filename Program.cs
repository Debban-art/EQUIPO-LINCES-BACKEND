using EQUIPO_LINCES_BACKEND.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using EQUIPO_LINCES_BACKEND.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddSingleton<UsuarioService>();
builder.Services.AddSingleton<RutasService>();
builder.Services.AddSingleton<LoginService>();
builder.Services.AddSingleton<NotificacionService>();
builder.Services.AddSingleton<HistorialNotificacionService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
