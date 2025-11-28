using System.Collections.ObjectModel;
using System.Windows.Input;
using proyecto_paradigmas_2025.Core;
using proyecto_paradigmas_2025.Data;
using proyecto_paradigmas_2025.Models;

namespace proyecto_paradigmas_2025.ViewModels
{
    public class GestionClientesViewModel : ViewModelBase
    {
        public ObservableCollection<Cliente> ListaClientes { get; set; }
        public ICommand VerHistorialCommand { get; set; }

        public GestionClientesViewModel(MainViewModel mainVM)
        {
            // Cargamos la lista del Singleton
            ListaClientes = new ObservableCollection<Cliente>(AlmacenDatos.Instancia.Clientes);

            VerHistorialCommand = new RelayCommand(parametro =>
            {
                if (parametro is Cliente clienteSeleccionado)
                {
                    // Navegamos al detalle de ese cliente
                    mainVM.VistaActual = new DetalleClienteViewModel(clienteSeleccionado, mainVM);
                }
            });
        }

        // Constructor vacío para el diseñador XAML
        public GestionClientesViewModel() { }
    }
}