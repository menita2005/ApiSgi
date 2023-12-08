namespace SGI.Models
{
    public class Productos
    {
        public int ProductosId { get; set; }
        public required string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        // Relaciones
        public int CategoriasId { get; set; }
        public Categorias Categorias { get; set; }

        public int ProveedoresId { get; set; }
        public required Proveedores Proveedores { get; set; }
    }

}
