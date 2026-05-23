using System;
using System.Collections.Generic;
public class Musica
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

    public override string ToString()
    {
        return $"{Nombre} - {Artista} ({Anio}) Género: {Genero}";
    }
}