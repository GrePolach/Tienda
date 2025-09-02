using Microsoft.EntityFrameworkCore;
using Tienda.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar cadena de conexión a Railway
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// Agregar servicios de controladores (si tienes API o MVC)
builder.Services.AddControllers();

var app = builder.Build();

// Middleware básico (si quieres servir API)
app.MapControllers();

// Configurar puerto dinámico para Railway
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Urls.Add($"http://*:{port}");

app.Run();
