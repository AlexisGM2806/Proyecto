using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Representa una canción dentro del sistema.
    /// Implementa IItem para poder ser utilizada
    /// por el motor de recomendaciones.
    /// </summary>
    public class Musica : IItem
    {
        /// <summary>
        /// Nombre de la canción.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Artista o banda que interpreta la canción.
        /// </summary>
        public string Artista { get; set; }

        /// <summary>
        /// Año de lanzamiento de la canción.
        /// </summary>
        public int Anio { get; set; }

        /// <summary>
        /// Género musical de la canción.
        /// </summary>
        public string Genero { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de Musica
        /// con sus datos principales.
        /// </summary>
        /// <param name="nombre">Nombre de la canción.</param>
        /// <param name="artista">Artista.</param>
        /// <param name="anio">Año de lanzamiento.</param>
        /// <param name="genero">Género musical.</param>
        public Musica(string nombre, string artista, int anio, string genero)
        {
            Nombre = nombre;
            Artista = artista;
            Anio = anio;
            Genero = genero;
        }

        /// <summary>
        /// Determina si dos instancias de Musica son iguales
        /// comparando todos sus atributos sin distinguir mayúsculas.
        /// </summary>
        /// <param name="obj">Objeto a comparar.</param>
        /// <returns>True si todos los atributos coinciden, false en caso contrario.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Musica other = (Musica)obj;

            return Nombre.Equals(other.Nombre, StringComparison.InvariantCultureIgnoreCase) &&
                   Artista.Equals(other.Artista, StringComparison.InvariantCultureIgnoreCase) &&
                   Anio == other.Anio &&
                   Genero.Equals(other.Genero, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Calcula el hash de la instancia en base a todos sus atributos.
        /// </summary>
        /// <returns>Hash que identifica la canción.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Nombre, Artista, Anio, Genero);
        }

        /// <summary>
        /// Devuelve una representación en texto de la canción.
        /// </summary>
        /// <returns>String con nombre, artista, año y género.</returns>
        public override string ToString()
        {
            return $"{Nombre} - {Artista} ({Anio}) Género: {Genero}";
        }
    }
}