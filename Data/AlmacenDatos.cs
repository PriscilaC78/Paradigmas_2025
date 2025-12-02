using System.Collections.Generic;
using proyecto_paradigmas_2025.Models;
// No olvides este using para que reconozca 'Reparacion', 'Cliente', etc.

namespace proyecto_paradigmas_2025.Data
{
    public class AlmacenDatos
    {
        // --- PATRÓN SINGLETON ---
        private static AlmacenDatos _instancia;

        // Constructor Privado: Evita que alguien haga "new AlmacenDatos()" por error.
        private AlmacenDatos() //Encapsulamiento
        {
            Clientes = new List<Cliente>();
            Reparaciones = new List<Reparacion>();
            Inventario = new List<Componente>();
        }

        // Punto de acceso global (siempre devuelve la misma instancia)
        public static AlmacenDatos Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new AlmacenDatos();
                }
                return _instancia;
            }
        }
        // ------------------------

        // Listas en Memoria (Tus tablas de BD)
        public List<Cliente> Clientes { get; private set; } //Encapsulamiento
        public List<Reparacion> Reparaciones { get; private set; } //Encapsulamiento
        public List<Componente> Inventario { get; private set; } //Encapsulamiento
    }
}