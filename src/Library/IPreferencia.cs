using System;

namespace Library
{
    /// <summary>
    /// Define el comportamiento asociado a una preferencia
    /// que puede aplicarse sobre un ítem del sistema.
    /// </summary>
    public interface IPreferencia
    {
        /// <summary>
        /// Obtiene un valor que indica si la preferencia
        /// representa una valoración positiva.
        /// </summary>
        bool MeGusta { get; }

        /// <summary>
        /// Calcula una valoración para el ítem especificado
        /// según la preferencia actual.
        /// </summary>
        /// <param name="item">Ítem a valorar.</param>
        /// <returns>
        /// Valor numérico asociado a la valoración del ítem.
        /// </returns>
        int ValorarItem(IItem item);
    }
}
