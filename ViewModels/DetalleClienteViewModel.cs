using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using proyecto_paradigmas_2025.Core;
using proyecto_paradigmas_2025.Data;
using proyecto_paradigmas_2025.Models;

namespace proyecto_paradigmas_2025.ViewModels
{
    public class DetalleClienteViewModel : ViewModelBase
    {
        public Cliente ClienteActual { get; set; }

        // Esta lista mostrará solo los equipos de ESTE cliente
        public ObservableCollection<Reparacion> HistorialReparaciones { get; set; }

        public ICommand VolverCommand { get; set; }

        public DetalleClienteViewModel(Cliente cliente, MainViewModel mainVM)
        {
            ClienteActual = cliente;

            // LÓGICA DE NEGOCIO: Filtrar del almacén global las reparaciones de este cliente
            var historial = AlmacenDatos.Instancia.Reparaciones
                            .Where(r => r.Cliente == cliente) // Compara referencias de memoria
                            .ToList();

            HistorialReparaciones = new ObservableCollection<Reparacion>(historial);

            VolverCommand = new RelayCommand(o =>
            {
                mainVM.VistaActual = new GestionClientesViewModel(mainVM);
            });
        }
    }
}