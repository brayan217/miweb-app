using System.Collections.Generic;

namespace MiWeb.Models
{
    public class CheckoutViewModel
    {
        public List<CarritoItem> Items { get; set; } = new List<CarritoItem>();
        public decimal Total { get; set; }
        public string DireccionEnvio { get; set; } = string.Empty;
        public string MetodoPago { get; set; } = string.Empty;
    }
}
