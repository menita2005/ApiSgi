namespace SGI.Models
{
    public class Compras
    {
        public int ComprasId { get; set; }
        public DateTime Fecha { get; set; }
        public int ProductosId { get; set; }
        public Productos Productos { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }

        // Otros campos relevantes para una compra (proveedor, etc.)
    }

}
