namespace Tienda.Models
{
     
    


        public class Pedido
        {
            public List<Producto> productos { get; set; } = new List<Producto>();


            public int Id { get; set; }
            public DateTime fecha_Hora { get; set; }
        }

  
}
