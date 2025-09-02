using Microsoft.EntityFrameworkCore;
using Tienda.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar cadena de conexión (MySQL) desde appsettings.json o variable de entorno
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? Environment.GetEnvironmentVariable("DATABASE_URL"); 

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// Agregar servicios de MVC (controladores y vistas)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware
app.UseStaticFiles();      // Para servir wwwroot (CSS, JS, imágenes)
app.UseRouting();          // Configurar rutas
app.UseAuthorization();    // Si usas autenticación

// Configurar rutas MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// Configurar puerto dinámico para Railway
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://*:{port}");

app.Run();
