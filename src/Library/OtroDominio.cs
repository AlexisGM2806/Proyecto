using System;

namespace Library
{
    /// <summary>
    /// Representa un ítem perteneciente a un dominio distinto al musical.
    /// Se utiliza principalmente para pruebas relacionadas con validaciones
    /// de tipo dentro del sistema de preferencias.
    /// </summary>
    public class OtroDominio : IItem
    {
        /// <summary>
        /// Obtiene o establece el nombre identificador del ítem.
        /// </summary>
        public string Nombre { get; set; }
    }
}
