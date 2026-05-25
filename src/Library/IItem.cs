using System;

namespace Library
{
    /// <summary>
    /// Define las operaciones y propiedades básicas que debe implementar
    /// cualquier ítem manejado por el sistema.
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// Obtiene el nombre identificador del ítem.
        /// </summary>
        string Nombre { get; }

        /// <summary>
        /// Determina si el ítem actual es igual a otro objeto.
        /// </summary>
        /// <param name="obj">Objeto a comparar con la instancia actual.</param>
        /// <returns>
        /// True si el objeto especificado es equivalente al ítem actual;
        /// false en caso contrario.
        /// </returns>
        bool Equals(object obj);

        /// <summary>
        /// Obtiene un código hash asociado al ítem actual.
        /// </summary>
        /// <returns>
        /// Valor hash que representa de forma única la instancia actual.
        /// </returns>
        int GetHashCode();

        /// <summary>
        /// Devuelve una representación textual del ítem.
        /// </summary>
        /// <returns>
        /// Cadena de texto que representa la información del ítem.
        /// </returns>
        string ToString();
    }
}
