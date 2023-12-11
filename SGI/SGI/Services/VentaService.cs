using SGI.Models;
using SGI.Data;

namespace SGI.Services
{
    public class VentaService : IVentaService
    {
        private readonly ApplicationDbContext _context;

        public VentaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> CalcularPrecioUnitario(VentaItem detalle)
        {
          
            return (decimal)detalle.Precio;
        }

        public async Task<decimal> CalcularSubtotalVentaDetalle(VentaItem detalle)
        {
            decimal precioUnitario = await CalcularPrecioUnitario(detalle);
            detalle.Subtotal = precioUnitario * detalle.Cantidad;

            return (decimal)detalle.Subtotal;
        }

        public decimal CalcularTotalVentaDetalles(List<VentaItem> detalles)
        {
            decimal total = 0;
            foreach (var detalle in detalles)
            {
                total += (decimal)detalle.Subtotal;
            }

            return total;
        }
    }
}
