using SGI.Models;

namespace SGI.Services
{

    public interface ICompraService
    {
        Task<decimal> CalcularPrecioUnitario(CompraItem detalle);
        Task<decimal> CalcularSubtotalCompraDetalle(CompraItem detalle);
        decimal CalcularTotalCompraDetalles(List<CompraItem> detalles);
    }
}