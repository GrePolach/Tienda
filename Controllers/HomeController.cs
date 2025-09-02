using Microsoft.AspNetCore.Mvc;
using Tienda.Models; // tu modelo Producto
using Tienda.Data;   // tu DbContext
using System.Linq;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Trae todos los productos de la base de datos
        var productos = _context.Productos.ToList();
        return View(productos);
    }
}