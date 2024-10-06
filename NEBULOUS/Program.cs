var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Variable para la cadena de conexión a bd
builder.Services.AddSingleton(builder.Configuration.GetConnectionString("connection_sql"));

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true; 
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSession();

app.MapControllers();

app.Run();
