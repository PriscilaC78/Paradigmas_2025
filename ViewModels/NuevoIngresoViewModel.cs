using System;
using System.Windows;
using System.Windows.Input;
using proyecto_paradigmas_2025.Core;
using proyecto_paradigmas_2025.Data;
using proyecto_paradigmas_2025.Models;
using proyecto_paradigmas_2025.Models.Equipos;

namespace proyecto_paradigmas_2025.ViewModels
{
    public class NuevoIngresoViewModel : ViewModelBase
    {
        // --- 1. Datos del Cliente ---
        public string NombreCliente { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }

        // --- 2. Selección de Tipo (Polimorfismo UI) ---
        private bool _esCelular = true; // Por defecto seleccionado
        public bool EsCelular
        {
            get { return _esCelular; }
            set
            {
                _esCelular = value;
                OnPropertyChanged(); // Avisar a la vista para ocultar/mostrar paneles
                OnPropertyChanged(nameof(EsComputadora)); // El opuesto cambia también
            }
        }
        public bool EsComputadora
        {
            get { return !EsCelular; }
            set
            {
                // Si la vista nos dice que EsComputadora es TRUE,
                // entonces forzamos a EsCelular a ser FALSE.
                if (value)
                {
                    EsCelular = false;
                }
            }
        }

        // --- 3. Datos Comunes del Equipo ---
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Falla { get; set; }

        // --- 4. Datos Específicos (Celular) ---
        public string IMEI { get; set; }
        public string Patron { get; set; }

        // --- 5. Datos Específicos (PC) ---
        public string SistemaOperativo { get; set; }
        public bool IncluyeCargador { get; set; }

        // --- COMANDOS ---
        public ICommand GuardarCommand { get; set; }

        public NuevoIngresoViewModel()
        {
            GuardarCommand = new RelayCommand(Guardar);
        }

        private void Guardar(object obj)
        {
            // 1. Validaciones básicas (puedes agregar más)
            if (string.IsNullOrEmpty(NombreCliente) || string.IsNullOrEmpty(Marca))
            {
                MessageBox.Show("Por favor complete nombre y marca como mínimo.");
                return;
            }

            // 2. Crear Cliente
            var nuevoCliente = new Cliente
            {
                Id = new Random().Next(100, 9999), // ID temporal random
                NombreCompleto = NombreCliente,
                DNI = DNI,
                Telefono = Telefono
            };

            // 3. Crear Equipo (POLIMORFISMO EN ACCIÓN)
            Equipo equipoNuevo;

            if (EsCelular)
            {
                equipoNuevo = new Celular
                {
                    Marca = Marca,
                    Modelo = Modelo,
                    DescripcionFalla = Falla,
                    IMEI = IMEI,
                    CodigoDesbloqueo = Patron,
                    TienePatron = !string.IsNullOrEmpty(Patron)
                };
            }
            else
            {
                equipoNuevo = new Computadora
                {
                    Marca = Marca,
                    Modelo = Modelo,
                    DescripcionFalla = Falla,
                    SistemaOperativo = SistemaOperativo,
                    IncluyeCargador = IncluyeCargador
                };
            }

            // Asignar ID al equipo
            equipoNuevo.Id = new Random().Next(100, 9999);

            // 4. Crear la Reparación
            var nuevaReparacion = new Reparacion
            {
                Id = new Random().Next(100, 9999),
                Cliente = nuevoCliente,
                Equipo = equipoNuevo,
                FechaIngreso = DateTime.Now,
                Estado = EstadoReparacion.EnEspera,
                ManoDeObra = 0 // Se define después
            };

            // 5. Guardar en Singleton
            AlmacenDatos.Instancia.Reparaciones.Add(nuevaReparacion);
            AlmacenDatos.Instancia.Clientes.Add(nuevoCliente);

            MessageBox.Show("Ingreso registrado con éxito!");

            // Opcional: Limpiar campos aquí...
        }
    }
}