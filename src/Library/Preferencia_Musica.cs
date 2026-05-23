public class Preferencia_Musica
{
    public List<string> Generos { get; set; }        
    public List<string> Artistas { get; set; }
    public int Decada { get; set; }                           
    public bool MeGusta { get; set; }                         

    public Preferencia_Musica(List<string> generos, List<string> artistas, int decada, bool meGusta)
    {
        Generos = generos;
        Artistas = artistas;
        Decada = decada;
        MeGusta = meGusta;                                    
    }

}