var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Variable para la cadena de conexión a bd
builder.Services.AddSingleton(builder.Configuration.GetConnectionString("connection_sql"));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
