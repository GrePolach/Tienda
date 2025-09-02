using Microsoft.EntityFrameworkCore;
using Tienda.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexión a Railway
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// Agregar servicios MVC (controladores con vistas)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar puerto dinámico para Railway
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://*:{port}");

// Habilitar archivos estáticos (wwwroot)
app.UseStaticFiles();

// Habilitar rutas MVC
app.UseRouting();

app.UseAuthorization();

// Ruta por defecto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// Opción adicional: respuesta simple en "/"
app.MapGet("/", () => "La tienda está en línea!");

// Ejecutar aplicación
app.Run();
