using System;

namespace Library;

public class Interaccion
{
    public Usuario Usuario { get; private set; }
    public IItem Item { get; private set; }
    public Interaccion (Usuario usuario, IItem item)
    {
        this.usuario=usuario;
        this.item = item;
    }
}
