using proyecto_paradigmas_2025.Models.Base;

namespace proyecto_paradigmas_2025.Models
{
    public class Componente : EntidadBase
    {
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PrecioVenta { get; set; } // Precio al público
    }
}