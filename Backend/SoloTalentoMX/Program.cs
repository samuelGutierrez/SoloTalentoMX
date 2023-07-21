using Microsoft.EntityFrameworkCore;
using SoloTalentoMX.Api.BussinessLogic.Interfaces;
using SoloTalentoMX.Api.BussinessLogic.Services;
using SoloTalentoMX.Data.Data;
using SoloTalentoMX.Data.Interfaces;
using SoloTalentoMX.Data.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddScoped(typeof(IGeneric<>), typeof(DaoGeneric<>));
builder.Services.AddScoped<IClientesServices, ClientesServices>();
builder.Services.AddScoped<IUsuariosServices, UsuariosServices>();
builder.Services.AddScoped<IAdministradorServices, AdministradorServices>();
builder.Services.AddScoped<ITiendasServices, TiendasServices>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Config Database Connection
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"))
);

var app = builder.Build();

// Dependency Injection and migration configure Database
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<Context>();
    dataContext.Database.Migrate();
}

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
