namespace proyecto_paradigmas_2025.Models.Equipos
{
    public class Celular : Equipo
    {
        public bool TienePatron { get; set; }
        public string CodigoDesbloqueo { get; set; } // PIN o Patrón dibujado (texto)
        public string IMEI { get; set; }

        // Implementación del método abstracto
        public override string ObtenerDatosEspecificos()
        {
            string seguridad = TienePatron ? $"Patrón/PIN: {CodigoDesbloqueo}" : "Sin bloqueo";
            return $"IMEI: {IMEI} | {seguridad}";
        }
    }
}