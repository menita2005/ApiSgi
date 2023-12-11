using SGI.Models;

namespace SGI.Services
{
    public interface IVentaService
    {
        Task<decimal> CalcularPrecioUnitario(VentaItem detalle);
        Task<decimal> CalcularSubtotalVentaDetalle(VentaItem detalle);
        decimal CalcularTotalVentaDetalles(List<VentaItem> detalles);
    }
}

