using proyecto_paradigmas_2025.Models.Base;

namespace proyecto_paradigmas_2025.Models
{
    public class Cliente : EntidadBase
    {
        public string NombreCompleto { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        // Sobreescritura de ToString para facilitar el DataBinding en WPF
        public override string ToString()
        {
            return $"{NombreCompleto} ({DNI})";
        }
    }
}