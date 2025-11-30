# 📱 Sistema de Gestión de Reparaciones (Tech Repair)

> **Proyecto Académico - Paradigmas de Programación 2025**
>
> Ingeniería en Sistemas de Información

![Status](https://img.shields.io/badge/Estado-Terminado-success)
![Language](https://img.shields.io/badge/C%23-WPF-blue)
![Framework](https://img.shields.io/badge/.NET-Framework%204.7.2-purple)
![Architecture](https://img.shields.io/badge/Patr%C3%B3n-MVVM-orange)

## 📋 Descripción

Este proyecto es una aplicación de escritorio desarrollada en **C# y WPF** que gestiona el flujo de trabajo integral de un taller de reparación de dispositivos electrónicos (Celulares y Computadoras).

El objetivo principal del proyecto es la **correcta implementación del Paradigma Orientado a Objetos (POO)** y el uso de buenas prácticas de arquitectura de software. El sistema permite registrar ingresos con lógica inteligente, gestionar estados de reparación mediante un tablero visual, administrar inventario de repuestos, controlar el historial de clientes y emitir facturas.

---

## 🚀 Características Principales

### 📊 Dashboard Inteligente
* **Tablero Kanban Visual:** Visualización del flujo de trabajo dividido en columnas (*En Espera, En Diagnóstico, En Reparación, Reparado*) para una gestión ágil.
* **KPIs Financieros:** Cálculo en tiempo real de la **Ganancia Estimada** (basada únicamente en reparaciones entregadas/cobradas) y el volumen de trabajo actual en taller.

### 🛠 Gestión de Reparaciones (Polimorfismo)
* **Soporte Multidispositivo:** Manejo transparente de **Celulares** (con propiedades únicas como IMEI, Patrón) y **Computadoras** (Sistema Operativo, Cargador) bajo una misma estructura abstracta polimórfica.
* **Flujo de Estados:** Control estricto del ciclo de vida del servicio.
* **Bloqueo de Seguridad:** El sistema bloquea la edición de campos técnicos y costos una vez que el equipo está finalizado (*Reparado*), y bloquea el cambio de estado una vez que se marca como *Entregado*, garantizando la integridad de los datos financieros.

### 👤 Módulo de Clientes
* **Directorio:** Listado completo de clientes con acceso directo a su información.
* **Historial Detallado:** Visualización de todas las reparaciones históricas asociadas a un cliente específico.
* **Detección Inteligente (Find or Create):** Al registrar un nuevo ingreso, el sistema busca por DNI si el cliente ya existe para reutilizar sus datos y evitar duplicados, o crea uno nuevo si no existe.

### 📦 Inventario y Facturación
* **Control de Stock:** CRUD completo para repuestos con precios de costo y venta diferenciados.
* **Consumo de Repuestos:** Al asignar un repuesto a una reparación, el stock se descuenta automáticamente y se actualiza el costo total del servicio en tiempo real.
* **Facturación:** Generación automática de comprobantes de servicio detallados en formato de archivo de texto (`.txt`) mediante un servicio dedicado.

---

## 🏗️ Arquitectura y Tecnologías

El proyecto sigue estrictamente el patrón de diseño **MVVM (Model-View-ViewModel)** para desacoplar la lógica de negocio de la interfaz de usuario, facilitando la mantenibilidad y el testeo.

### Conceptos de POO Aplicados
1.  **Herencia:** Clase base abstracta `Equipo` de la cual heredan `Celular` y `Computadora`. Clase base `EntidadBase` para manejo genérico de IDs.
2.  **Polimorfismo:**
    * Uso de colecciones genéricas que manejan tipos base `Equipo` pero comportan diferente según la instancia concreta.
    * Vistas dinámicas en "Nuevo Ingreso" que adaptan los campos visibles según el tipo de objeto seleccionado.
    * Grilla de reparaciones que muestra columnas con datos específicos según el tipo de equipo (IMEI vs SO).
3.  **Encapsulamiento:** Lógica de negocio protegida dentro de los modelos (ej: propiedades calculadas como `GananciaNeta` o `TotalPagar`).
4.  **Abstracción:** Uso de Servicios (`ServicioFacturacion`) para abstraer la complejidad de la creación de archivos del resto del sistema.

### Patrones de Diseño Utilizados
* **Singleton:** Implementado en la clase `AlmacenDatos` para simular una base de datos en memoria persistente y accesible globalmente durante la ejecución.
* **Command:** Uso de `RelayCommand` para manejar eventos de la UI (botones, acciones) sin código en el *Code-Behind* de las vistas.
* **Observer:** Implementación de `INotifyPropertyChanged` en la clase base `ViewModelBase` para garantizar la reactividad de la interfaz gráfica ante cambios en los datos.

---

## 📂 Estructura del Proyecto

```text
proyecto_paradigmas_2025
│
├── 📁 Core            # Clases base de infraestructura MVVM (RelayCommand, ViewModelBase)
├── 📁 Data            # Persistencia de datos (Singleton AlmacenDatos y Generador de Datos Dummy)
├── 📁 Models          # Definición de Entidades y Lógica de Dominio
│   ├── 📁 Base        # EntidadBase (ID)
│   ├── 📁 Equipos     # Jerarquía: Equipo (Abstract) -> Celular, Computadora
│   ├── Cliente.cs
│   ├── Componente.cs
│   └── Reparacion.cs
├── 📁 Services        # Lógica externa (Generación de Facturas TXT)
├── 📁 ViewModels      # Lógica de presentación, estado de las vistas y comandos
└── 📁 Views           # Interfaz de usuario (UserControls XAML y Estilos)
```
## 🔧 Instalación y Ejecución

### Prerrequisitos
* **Visual Studio** 2019, 2022 o compatible.
* **.NET Framework 4.7.2** instalado.

### Pasos
1.  **Clonar el repositorio:**
    ```bash
    git clone https://github.com/PriscilaC78/Paradigmas_2025.git
    ```
2.  **Abrir la solución:**
    Ejecuta el archivo `proyecto_paradigmas_2025.sln` con Visual Studio.
3.  **Compilar:**
    Ve al menú *Compilar* -> *Recompilar Solución* para restaurar dependencias y vincular las vistas XAML.
4.  **Ejecutar:**
    Presiona `F5` o el botón de Iniciar.

> **Nota sobre los datos:** Al no utilizar una base de datos física (SQL), el sistema utiliza persistencia en memoria RAM. Los datos se reinician cada vez que se cierra la aplicación. Se incluye una clase `GeneradorDatosFalsos` que precarga información de prueba al iniciar para facilitar las demostraciones.

---

## ✒️ Autores

* **Coria, Priscila Emilse**
* **kotowski, Alejandro David**
* **Chavez Reche, Marcelo Nahuel**
* **Balbuena, Tirsa**

---
*Proyecto realizado para la cátedra de Paradigmas de Programación - 2025.*
