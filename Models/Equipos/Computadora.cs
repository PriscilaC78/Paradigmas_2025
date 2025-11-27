namespace proyecto_paradigmas_2025.Models.Equipos
{
    public class Computadora : Equipo
    {
        public bool IncluyeCargador { get; set; }
        public string SistemaOperativo { get; set; } // Ej: Windows 10, Ubuntu
        public string ContrasenaUsuario { get; set; }

        // Implementación del método abstracto con lógica distinta al celular
        public override string ObtenerDatosEspecificos()
        {
            string accesorios = IncluyeCargador ? "Con Cargador" : "Solo equipo";
            return $"OS: {SistemaOperativo} | {accesorios}";
        }
    }
}