using System;

namespace proyecto_paradigmas_2025.Models.Base
{
    // Esta clase sirve para que cualquier objeto del sistema tenga un ID.
    // Facilita la búsqueda y edición en las listas en memoria.
    public abstract class EntidadBase
    {
        public int Id { get; set; }

        // Constructor vacío
        public EntidadBase() { }
    }
}