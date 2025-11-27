using System.Windows;
using proyecto_paradigmas_2025.Data;
using proyecto_paradigmas_2025.ViewModels;

namespace proyecto_paradigmas_2025
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 1. Cargamos datos de prueba en el Singleton
            GeneradorDatosFalsos.CargarDatosIniciales();

            // 2. Conectamos la VISTA con el VIEWMODEL
            this.DataContext = new MainViewModel();
        }
    }
}