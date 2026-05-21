using System;
using System.ComponentModel.DataAnnotations;

namespace Library;

public class Usuario
{
    public int Id { get; private set; }
    public string Nombre {get;private set;}
    public IPreferencia Gustos {get;private set;}
    public IPreferencia Disgustos {get;private set;}

    public Usuario (string nombre, IPreferencia gusto, IPreferencia disgusto,int id)
    {
        this.Id = id;
        this.Nombre = nombre;
        this.Gustos = gusto;
        this.Disgustos = disgusto;
    }
}
