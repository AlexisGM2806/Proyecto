using System.Collections.Generic;

namespace Library
{
    public class Preferencia_Musica : IPreferencia
    {
        public List<string> Generos { get; set; }        
        public List<string> Artistas { get; set; }
        public List<int> Decadas { get; set; }                           
        public bool MeGusta { get; set; }                         

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

        public Preferencia_Musica(List<string> generos, List<string> artistas, List<int> decadas, bool meGusta)
        {
            Generos = generos;
            Artistas = artistas;
            Decadas = decadas;
            MeGusta = meGusta;                                    
        }

    }
}