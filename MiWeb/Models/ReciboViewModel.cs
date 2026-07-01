using System;
using System.Collections.Generic;

namespace MiWeb.Models
{
    public class ReciboViewModel
    {
        public int PedidoId { get; set; }
        public string NumeroReferencia { get; set; }
        public string Fecha { get; set; }
        public string Cliente { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string MetodoPago { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public List<PedidoDetalle> Detalles { get; set; }
    }
}