using proyecto_paradigmas_2025.Models.Base;

namespace proyecto_paradigmas_2025.Models.Equipos
{
    // ABSTRACTA: No puedes hacer "new Equipo()", debes crear un hijo.
    public abstract class Equipo : EntidadBase
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string NumeroSerie { get; set; }
        public string DescripcionFalla { get; set; }

        // Propiedad de solo lectura para mostrar en listas
        public string NombreCompleto => $"{Marca} {Modelo}";

        // MÉTODO ABSTRACTO (Polimorfismo):
        // Obligamos a los hijos a definir cómo muestran sus datos técnicos específicos.
        public abstract string ObtenerDatosEspecificos();

        // Esto convierte el método en una Propiedad para que WPF pueda leerla.
        public string DatosTecnicos => ObtenerDatosEspecificos();
    }
}