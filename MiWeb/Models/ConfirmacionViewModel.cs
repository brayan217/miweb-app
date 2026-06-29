namespace MiWeb.Models
{
    public class ConfirmacionViewModel
    {
        public bool CompraExitosa { get; set; }
        public int NumeroPedido { get; set; }
        public string NumeroReferencia { get; set; } = string.Empty;
        public string TotalPagado { get; set; } = string.Empty;
        public string FechaCompra { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public string Fecha { get; set; } = string.Empty;
        public string DireccionEnvio { get; set; } = string.Empty;
        public string MetodoPago { get; set; } = string.Empty;
        public string Mensaje { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
    }
}
