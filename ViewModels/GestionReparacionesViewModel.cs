using System.Collections.ObjectModel;
using System.Windows.Input;
using proyecto_paradigmas_2025.Core;
using proyecto_paradigmas_2025.Data;
using proyecto_paradigmas_2025.Models;

namespace proyecto_paradigmas_2025.ViewModels
{
    public class GestionReparacionesViewModel : ViewModelBase
    {
        public ObservableCollection<Reparacion> ListaReparaciones { get; set; }
        public ICommand VerDetalleCommand { get; set; }

        // Necesitamos recibir el MainViewModel para poder cambiar la vista desde aquí
        public GestionReparacionesViewModel(MainViewModel mainVM)
        {
            var datos = AlmacenDatos.Instancia.Reparaciones;
            ListaReparaciones = new ObservableCollection<Reparacion>(datos);

            VerDetalleCommand = new RelayCommand(parametro =>
            {
                if (parametro is Reparacion reparacionSeleccionada)
                {
                    // Navegar a la vista de detalle enviando el objeto seleccionado
                    mainVM.VistaActual = new DetalleReparacionViewModel(reparacionSeleccionada, mainVM);
                }
            });
        }

        // Constructor vacío para que no rompa el diseño en tiempo de diseño (opcional)
        public GestionReparacionesViewModel() { }
    }
}