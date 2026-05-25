using System;
using System.ComponentModel.DataAnnotations;

namespace Library
{
    /// <summary>
    /// Guarda la información básica de un usuario del sistema.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Nombre que identifica al usuario.
        /// </summary>
        public string Nombre {get;private set;}

        /// <summary>
        /// Gustos asociados al usuario.
        /// </summary>
        public IPreferencia Gustos {get;private set;}

        /// <summary>
        /// Disgustos asociados al usuario.
        /// </summary>
        public IPreferencia Disgustos {get;private set;}

        /// <summary>
        /// Cambia los gustos actuales del usuario.
        /// </summary>
        /// <param name="nuevoGusto">Nuevo gusto a guardar.</param>
        public void ActualizarGustos (IPreferencia nuevoGusto)
        {
            Gustos = nuevoGusto;
        }

        /// <summary>
        /// Cambia los disgustos actuales del usuario.
        /// </summary>
        /// <param name="nuevoDisgusto">Nuevo disgusto a guardar.</param>
        public void ActualizarDisgustos (IPreferencia nuevoDisgusto)
        {
            Disgustos = nuevoDisgusto;
        }

        /// <summary>
        /// Crea un usuario con su nombre, gustos y disgustos iniciales.
        /// </summary>
        /// <param name="nombre">Nombre del usuario.</param>
        /// <param name="gusto">Gusto inicial del usuario.</param>
        /// <param name="disgusto">Disgusto inicial del usuario.</param>
        public Usuario (string nombre, IPreferencia gusto, IPreferencia disgusto)
        {
            this.Nombre = nombre;
            this.Gustos = gusto;
            this.Disgustos = disgusto;
        }

        /// <summary>
        /// Compara usuarios por nombre, sin importar mayúsculas o minúsculas.
        /// </summary>
        /// <param name="obj">Objeto con el que se compara.</param>
        /// <returns>True si tienen el mismo nombre, false si no.</returns>
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            return Nombre.Equals(((Usuario)obj).Nombre, StringComparison.InvariantCultureIgnoreCase);
        }
        
        /// <summary>
        /// Genera el hash usando el nombre del usuario.
        /// </summary>
        /// <returns>Hash del usuario.</returns>
        public override int GetHashCode()
        {
            return Nombre.GetHashCode();
        }

        /// <summary>
        /// Devuelve el nombre del usuario como texto.
        /// </summary>
        /// <returns>Nombre del usuario.</returns>
        public override string ToString()
        {
            return Nombre;
        }
    }
}