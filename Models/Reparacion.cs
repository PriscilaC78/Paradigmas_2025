using System;
using System.Collections.Generic; // Necesario para List<>
using proyecto_paradigmas_2025.Models.Base;
using proyecto_paradigmas_2025.Models.Equipos;

namespace proyecto_paradigmas_2025.Models
{
    // Enum para manejar estados fijos (puedes ponerlo en este mismo archivo o uno aparte)
    public enum EstadoReparacion
    {
        EnEspera,
        EnDiagnostico,
        EnReparacion,
        Reparado,
        Entregado,
        NoReparado
    }

    public class Reparacion : EntidadBase
    {
        // Relaciones (Composición)
        public Cliente Cliente { get; set; }

        // Polimorfismo: Aquí guardamos un Celular o una Computadora, no importa cuál
        public Equipo Equipo { get; set; }

        // Datos de la reparación
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaEntrega { get; set; } // El '?' permite que sea null
        public EstadoReparacion Estado { get; set; }
        public string DiagnosticoTecnico { get; set; }

        // Costos
        public decimal ManoDeObra { get; set; }
        public decimal Senia { get; set; } // Pago adelantado

        // Lista de repuestos usados (Relación de 1 a muchos)
        // Nota: Asumo que tienes la clase Componente.cs, si no la tienes la creamos abajo.
        public List<Componente> RepuestosUsados { get; set; } = new List<Componente>();

        // Propiedad calculada: Total a Pagar
        public decimal TotalPagar
        {
            get
            {
                decimal costoRepuestos = 0;
                foreach (var r in RepuestosUsados)
                {
                    costoRepuestos += r.PrecioVenta;
                }
                return ManoDeObra + costoRepuestos;
            }
        }

        public decimal SaldoPendiente => TotalPagar - Senia;
    }
}