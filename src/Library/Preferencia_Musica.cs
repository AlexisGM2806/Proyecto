using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Representa la preferencia de un usuario respecto a la música.
    /// Implementa IPreferencia para poder ser evaluada
    /// por el motor de recomendaciones de forma independiente al dominio.
    /// </summary>
    public class Preferencia_Musica : IPreferencia
    {
        /// <summary>
        /// Géneros musicales de preferencia del usuario.
        /// </summary>
        public List<string> Generos { get; set; }

        /// <summary>
        /// Artistas de preferencia del usuario.
        /// </summary>
        public List<string> Artistas { get; set; }

        /// <summary>
        /// Décadas de preferencia del usuario.
        /// </summary>
        public List<int> Decadas { get; set; }

        /// <summary>
        /// Indica si la preferencia es positiva o negativa.
        /// </summary>
        public bool MeGusta { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de Preferencia_Musica.
        /// </summary>
        /// <param name="generos">Géneros de preferencia.</param>
        /// <param name="artistas">Artistas de preferencia.</param>
        /// <param name="decadas">Décadas de preferencia.</param>
        /// <param name="meGusta">True si la preferencia es positiva, false si es negativa.</param>
        public Preferencia_Musica(List<string> generos, List<string> artistas, List<int> decadas, bool meGusta)
        {
            Generos = generos;
            Artistas = artistas;
            Decadas = decadas;
            MeGusta = meGusta;
        }

        /// <summary>
        /// Calcula un puntaje para un ítem dado en base a las preferencias del usuario.
        /// Si el ítem no es de tipo Musica devuelve 0.
        /// Si no hay datos de preferencia definidos, devuelve 30 en caso de MeGusta
        /// o 0 en caso contrario.
        /// Por cada coincidencia de género, artista o década suma 10 puntos.
        /// Si MeGusta es false, el puntaje final se invierte a negativo.
        /// </summary>
        /// <param name="item">Ítem a valorar.</param>
        /// <returns>Puntaje entero que representa la afinidad del usuario con el ítem.</returns>
        public int ValorarItem(IItem item)
        {
            if (!(item is Musica))
            {
                return 0;
            }

            bool sinDatos =
                (Generos == null || Generos.Count == 0) &&
                (Artistas == null || Artistas.Count == 0) &&
                (Decadas == null || Decadas.Count == 0);

            if (sinDatos)
            {
                if (MeGusta)
                {
                    return 30;
                }

                return 0;
            }

            int puntaje = 0;

            if (Generos != null && Generos.Contains(((Musica)item).Genero))
            {
                puntaje += 10;
            }
            if (Artistas != null && Artistas.Contains(((Musica)item).Artista))
            {
                puntaje += 10;
            }

            int decadaCancion = (((Musica)item).Anio / 10) * 10;

            if (Decadas != null && Decadas.Contains(decadaCancion))
            {
                puntaje += 10;
            }
            if (MeGusta == false)
            {
                puntaje *= -1;
            }

            return puntaje;
        }
    }
}