namespace SGI.Models
{
    public class Ventas
    {
        public int VentasId { get; set; }
        public DateTime Fecha { get; set; }
        public int ProductosId { get; set; }
        public Productos Productos { get; set; }
        public int Cantidades { get; set; }
        public decimal Total { get; set; }
    }

}
