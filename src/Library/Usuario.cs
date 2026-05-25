using System;
using System.ComponentModel.DataAnnotations;

namespace Library
{
    public class Usuario
    {
        public string Nombre {get;private set;}
        public IPreferencia Gustos {get;private set;}
        public IPreferencia Disgustos {get;private set;}

        public void ActualizarGustos (IPreferencia nuevoGusto)
        {
            Gustos = nuevoGusto;
        }

        public void ActualizarDisgustos (IPreferencia nuevoDisgusto)
        {
            Disgustos = nuevoDisgusto;
        }

        public Usuario (string nombre, IPreferencia gusto, IPreferencia disgusto)
        {
            this.Nombre = nombre;
            this.Gustos = gusto;
            this.Disgustos = disgusto;
        }
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            return Nombre.Equals(((Usuario)obj).Nombre, StringComparison.InvariantCultureIgnoreCase);
        }
        
        public override int GetHashCode()
        {
            return Nombre.GetHashCode();
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
