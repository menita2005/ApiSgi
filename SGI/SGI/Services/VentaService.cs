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

        public async Task<Double> CalcularPrecioUnitario(VentaItem detalle)
        {
          
            return (Double)detalle.Precio;
        }

        public async Task<Double> CalcularSubtotalVentaDetalle(VentaItem detalle)
        {
            Double precioUnitario = await CalcularPrecioUnitario(detalle);
            detalle.Subtotal = precioUnitario * detalle.Cantidad;

            return (Double)detalle.Subtotal;
        }

        public Double CalcularTotalVentaDetalles(List<VentaItem> detalles)
        {
            Double total = 0;
            foreach (var detalle in detalles)
            {
                total += (double)detalle.Subtotal;
            }

            return total;
        }
    }
}
