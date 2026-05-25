using System;

namespace Library
{
    /// <summary>
    /// Representa una interacción entre un usuario y un ítem dentro del sistema.
    /// </summary>
    public class Interaccion
    {
        /// <summary>
        /// Usuario que realiza la interacción.
        /// </summary>
        public Usuario Usuario { get; private set; }

        /// <summary>
        /// Ítem asociado a la interacción.
        /// </summary>
        public IItem Item { get; private set; }

        /// <summary>
        /// Inicializa una nueva instancia de Interaccion con un usuario y un ítem.
        /// </summary>
        /// <param name="usuario">Usuario que realiza la interacción.</param>
        /// <param name="item">Ítem asociado a la interacción.</param>
        public Interaccion (Usuario usuario, IItem item)
        {
            this.Usuario=usuario;
            this.Item = item;
        }

        /// <summary>
        /// Determina si dos instancias de Interaccion son iguales comparando su usuario y su ítem.
        /// </summary>
        /// <param name="obj">Objeto a comparar.</param>
        /// <returns>True si ambas interacciones tienen el mismo usuario y el mismo ítem, false en caso contrario.</returns>
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
    
        /// <summary>
        /// Calcula el hash de la instancia en base al usuario y al ítem.
        /// </summary>
        /// <returns>Hash que identifica la interacción.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Usuario,Item);
        }

        /// <summary>
        /// Devuelve una representación en texto de la interacción.
        /// </summary>
        /// <returns>String con el usuario y el ítem de la interacción.</returns>
        public override string ToString()
        {
            return $"Usuario: {Usuario.ToString()} | Item: {Item.ToString()}";
        }
    }
}