﻿using SGI.Models;
using SGI.Data;

namespace SGI.Services
{
    public class CompraService : ICompraService
    {
        private readonly ApplicationDbContext _context;

        public CompraService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Producto> ObtenerProductoPorId(int productoId)
        {
            var producto = await _context.Productos.FindAsync(productoId);
            if (producto == null)
            {
                throw new Exception($"El producto con ID {productoId} no fue encontrado.");
            }
            return producto;
        }

        public async Task<double> CalcularPrecioUnitario(CompraItem detalle)
        {
            var producto = await ObtenerProductoPorId(detalle.ProductoId);
            detalle.Precio = producto.Precio;

            return (double)detalle.Precio;
        }

        public async Task<double> CalcularSubtotalCompraDetalle(CompraItem detalle)
        {
            double precioUnitario = await CalcularPrecioUnitario(detalle);
            detalle.Subtotal = precioUnitario * detalle.Cantidad;

            return (double)detalle.Subtotal;
        }

        public double CalcularTotalCompraDetalles(List<CompraItem> detalles)
        {
            double total = 0;
            foreach (var detalle in detalles)
            {
                total += (double)detalle.Subtotal;
            }

            return total;
        }
    }
}
