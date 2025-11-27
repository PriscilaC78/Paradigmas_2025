using System.Collections.ObjectModel;
using proyecto_paradigmas_2025.Core;
using proyecto_paradigmas_2025.Data;
using proyecto_paradigmas_2025.Models;

namespace proyecto_paradigmas_2025.ViewModels
{
    public class GestionReparacionesViewModel : ViewModelBase
    {
        // Usamos ObservableCollection en lugar de List porque avisa a la UI si se agrega/borra algo
        public ObservableCollection<Reparacion> ListaReparaciones { get; set; }

        public GestionReparacionesViewModel()
        {
            // Cargar datos del Singleton
            var datos = AlmacenDatos.Instancia.Reparaciones;
            ListaReparaciones = new ObservableCollection<Reparacion>(datos);
        }
    }
}