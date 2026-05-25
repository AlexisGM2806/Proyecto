using System;

namespace Library
{
    public class Interaccion
    {
        public Usuario Usuario { get; private set; }
        public IItem Item { get; private set; }
        public Interaccion (Usuario usuario, IItem item)
        {
            this.Usuario=usuario;
            this.Item = item;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Interaccion other = (Interaccion)obj;

            return Usuario.Equals(other.Usuario) &&
                   Item.Equals(other.Item);
        }
    
        public override int GetHashCode()
        {
            return HashCode.Combine(Usuario,Item);
        }

        public override string ToString()
        {
            return $"Usuario: {Usuario.ToString()} | Item: {Item.ToString()}";
        }
    }
}
