using System.Linq;
using proyecto_paradigmas_2025.Core;
using proyecto_paradigmas_2025.Data;
using proyecto_paradigmas_2025.Models; // Para acceder al Enum EstadoReparacion

namespace proyecto_paradigmas_2025.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        // Propiedades para mostrar en las "Tarjetas" del dashboard
        public int CantidadPendientes { get; set; }
        public int CantidadEnTaller { get; set; }
        public int CantidadListos { get; set; }
        public decimal DineroRecaudadoHoy { get; set; }

        public DashboardViewModel()
        {
            CargarEstadisticas();
        }

        private void CargarEstadisticas()
        {
            // Accedemos a los datos en memoria (Singleton)
            var datos = AlmacenDatos.Instancia;

            // Usamos LINQ para filtrar y contar (Programación Funcional básica)

            // 1. Pendientes (En espera o Diagnóstico)
            CantidadPendientes = datos.Reparaciones
                .Count(r => r.Estado == EstadoReparacion.EnEspera || r.Estado == EstadoReparacion.EnDiagnostico);

            // 2. En Taller (En reparación)
            CantidadEnTaller = datos.Reparaciones
                .Count(r => r.Estado == EstadoReparacion.EnReparacion);

            // 3. Listos para entregar (Reparados)
            CantidadListos = datos.Reparaciones
                .Count(r => r.Estado == EstadoReparacion.Reparado);

            // Nota: Al ser propiedades simples (int), no necesito OnPropertyChanged aquí 
            // porque se asignan en el constructor antes de que la vista se muestre.
        }
    }
}