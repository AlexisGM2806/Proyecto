using System;
using System.Collections.Generic;

namespace Library
{
    public class Musica : IItem
    {
        public string Nombre { get; set; }
        public string Artista { get; set; }
        public int Anio { get; set; }
        public string Genero { get; set; }  

        public Musica(string nombre, string artista, int anio, string genero)
        {
            Nombre = nombre;
            Artista = artista;
            Anio = anio;
            Genero = genero;
        }

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
    
        public override int GetHashCode()
        {
            return HashCode.Combine(Nombre, Artista, Anio, Genero);
        }

        public override string ToString()
        {
            return $"{Nombre} - {Artista} ({Anio}) Género: {Genero}";
        }
    }
}