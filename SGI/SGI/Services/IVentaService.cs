using SGI.Models;

namespace SGI.Services
{
    public interface IVentaService
    {
        Task<Double> CalcularPrecioUnitario(VentaItem detalle);
        Task<Double> CalcularSubtotalVentaDetalle(VentaItem detalle);
        Double CalcularTotalVentaDetalles(List<VentaItem> detalles);
    }
}

