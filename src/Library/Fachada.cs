using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    /// <summary>
    /// Proporciona una interfaz simplificada de acceso
    /// a las funcionalidades principales del sistema.
    /// </summary>
    public class Fachada
    {
        /// <summary>
        /// Añade un nuevo usuario al sistema.
        /// </summary>
        /// <param name="nuevoUsuario">
        /// Usuario que se desea registrar.
        /// </param>
        public void AñadirUsuario(Usuario nuevoUsuario)
        {
            Controlador.AñadirUsuario(nuevoUsuario);
        }

        /// <summary>
        /// Añade un nuevo ítem al sistema.
        /// </summary>
        /// <param name="nuevoItem">
        /// Ítem que se desea agregar.
        /// </param>
        public void AñadirItem(IItem nuevoItem)
        {
            Controlador.AñadirItem(nuevoItem);
        }

        /// <summary>
        /// Registra una nueva interacción entre un usuario y un ítem.
        /// </summary>
        /// <param name="nuevaInteraccion">
        /// Interacción que se desea registrar.
        /// </param>
        public void AñadirInteraccion(Interaccion nuevaInteraccion)
        {
            Controlador.AñadirInteraccion(nuevaInteraccion);
        }

        /// <summary>
        /// Obtiene un ranking de ítems ordenados
        /// según la cantidad de interacciones registradas.
        /// </summary>
        /// <returns>
        /// Lista de ítems ordenados por popularidad.
        /// </returns>
        public List<IItem> RankingPorInteracciones()
        {
            return Controlador.RankingPorInteracciones();
        }

        /// <summary>
        /// Obtiene un ranking de recomendaciones
        /// para el usuario especificado.
        /// </summary>
        /// <param name="usuario">
        /// Usuario para el cual se desea generar el ranking.
        /// </param>
        /// <returns>
        /// Lista de ítems recomendados para el usuario.
        /// </returns>
        public List<IItem> RankingPorPreferencia(Usuario usuario)
        {
            return Controlador.RankingPorPreferencia(usuario);
        }

        /// <summary>
        /// Busca un usuario por nombre.
        /// </summary>
        /// <param name="nombre">
        /// Nombre del usuario a buscar.
        /// </param>
        /// <returns>
        /// Usuario encontrado o null si no existe coincidencia.
        /// </returns>
        public Usuario GetUsuario(string nombre)
        {
            return Controlador.GetUsuario(nombre);
        }

        /// <summary>
        /// Busca un ítem por nombre.
        /// </summary>
        /// <param name="nombre">
        /// Nombre del ítem a buscar.
        /// </param>
        /// <returns>
        /// Ítem encontrado o null si no existe coincidencia.
        /// </returns>
        public IItem GetItem(string nombre)
        {
            return Controlador.GetItem(nombre);
        }

        /// <summary>
        /// Busca una interacción específica entre un usuario y un ítem.
        /// </summary>
        /// <param name="usuario">
        /// Usuario asociado a la interacción.
        /// </param>
        /// <param name="item">
        /// Ítem asociado a la interacción.
        /// </param>
        /// <returns>
        /// Interacción encontrada o null si no existe coincidencia.
        /// </returns>
        public Interaccion GetInteraccion(Usuario usuario, IItem item)
        {
            return Controlador.GetInteraccion(usuario, item);
        }

        /// <summary>
        /// Obtiene la colección de usuarios registrados.
        /// </summary>
        /// <returns>
        /// Lista de usuarios del sistema.
        /// </returns>
        public List<Usuario> GetUsuarios()
        {
            return Controlador.GetUsuarios();
        }

        /// <summary>
        /// Obtiene la colección de interacciones registradas.
        /// </summary>
        /// <returns>
        /// Lista de interacciones del sistema.
        /// </returns>
        public List<Interaccion> GetInteracciones()
        {
            return Controlador.GetInteracciones();
        }

        /// <summary>
        /// Obtiene la colección de ítems disponibles en el sistema.
        /// </summary>
        /// <returns>
        /// Lista de ítems registrados.
        /// </returns>
        public List<IItem> GetItems()
        {
            return Controlador.GetItems();
        }
    }
}
