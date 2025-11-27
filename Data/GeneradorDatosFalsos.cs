using System;
using System.Collections.Generic;
using proyecto_paradigmas_2025.Models;
using proyecto_paradigmas_2025.Models.Equipos;

namespace proyecto_paradigmas_2025.Data
{
    public static class GeneradorDatosFalsos
    {
        public static void CargarDatosIniciales()
        {
            var datos = AlmacenDatos.Instancia;

            // 1. Si ya hay datos, no hacemos nada
            if (datos.Clientes.Count > 0) return;

            // 2. Crear Clientes
            var cliente1 = new Cliente { Id = 1, NombreCompleto = "Juan Perez", DNI = "12345678", Telefono = "3644-111111", Email = "juan@mail.com" };
            var cliente2 = new Cliente { Id = 2, NombreCompleto = "Maria Gomez", DNI = "87654321", Telefono = "3644-222222", Email = "maria@mail.com" };

            datos.Clientes.Add(cliente1);
            datos.Clientes.Add(cliente2);

            // 3. Crear Inventario (Componentes)
            var comp1 = new Componente { Id = 1, Nombre = "Pantalla Samsung A50", Stock = 5, PrecioCosto = 5000, PrecioVenta = 8500 };
            var comp2 = new Componente { Id = 2, Nombre = "Disco SSD 240GB", Stock = 10, PrecioCosto = 3000, PrecioVenta = 5500 };

            datos.Inventario.Add(comp1);
            datos.Inventario.Add(comp2);

            // 4. Crear Reparaciones (Aquí aplicamos HERENCIA y POLIMORFISMO)

            // Caso A: Un Celular
            var reparacionCel = new Reparacion
            {
                Id = 1,
                Cliente = cliente1,
                FechaIngreso = DateTime.Now.AddDays(-2),
                Estado = EstadoReparacion.EnDiagnostico,
                ManoDeObra = 2000,
                Equipo = new Celular // <--- Polimorfismo
                {
                    Marca = "Samsung",
                    Modelo = "A50",
                    IMEI = "111222333444",
                    DescripcionFalla = "No carga la batería",
                    TienePatron = true,
                    CodigoDesbloqueo = "1234"
                }
            };

            // Caso B: Una Computadora
            var reparacionPC = new Reparacion
            {
                Id = 2,
                Cliente = cliente2,
                FechaIngreso = DateTime.Now.AddDays(-5),
                Estado = EstadoReparacion.Reparado,
                ManoDeObra = 3000,
                DiagnosticoTecnico = "Se realizó cambio de disco y formateo.",
                Equipo = new Computadora // <--- Polimorfismo
                {
                    Marca = "Dell",
                    Modelo = "Inspiron",
                    NumeroSerie = "XJ900",
                    DescripcionFalla = "Windows muy lento",
                    SistemaOperativo = "Windows 10",
                    IncluyeCargador = true
                }
            };

            // Simular que usamos un repuesto en la PC
            reparacionPC.RepuestosUsados.Add(comp2);

            datos.Reparaciones.Add(reparacionCel);
            datos.Reparaciones.Add(reparacionPC);
        }
    }
}