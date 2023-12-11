using SGI.Models;

namespace SGI.Services
{

    public interface ICompraService
    {
        Task<double> CalcularPrecioUnitario(CompraItem detalle);
        Task<double> CalcularSubtotalCompraDetalle(CompraItem detalle);
        double CalcularTotalCompraDetalles(List<CompraItem> detalles);
    }
}