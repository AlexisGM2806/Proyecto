using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    /// <summary>
    /// Centraliza la administración de usuarios, ítems e interacciones
    /// del sistema, además de coordinar la generación de rankings
    /// y recomendaciones.
    /// </summary>
    public class Controlador
    {
        /// <summary>
        /// Colección de usuarios registrados en el sistema.
        /// </summary>
        private static List<Usuario> usuarios;

        /// <summary>
        /// Colección de ítems disponibles en el sistema.
        /// </summary>
        private static List<IItem> items;

        /// <summary>
        /// Colección de interacciones registradas entre usuarios e ítems.
        /// </summary>
        private static List<Interaccion> interacciones;

        /// <summary>
        /// Instancia utilizada para generar rankings y recomendaciones.
        /// </summary>
        private static Motor motor;

        /// <summary>
        /// Inicializa las colecciones principales del sistema.
        /// </summary>
        /// <param name="usuariosIniciales">
        /// Lista inicial de usuarios.
        /// </param>
        /// <param name="itemsIniciales">
        /// Lista inicial de ítems.
        /// </param>
        /// <param name="interaccionesIniciales">
        /// Lista inicial de interacciones.
        /// </param>
        public static void Inicializar(List<Usuario> usuariosIniciales, List<IItem> itemsIniciales, List<Interaccion> interaccionesIniciales)
        {
            usuarios = usuariosIniciales;
            items = itemsIniciales;
            interacciones = interaccionesIniciales;
        }

        /// <summary>
        /// Añade un nuevo usuario al sistema si no existe previamente
        /// otro usuario con el mismo nombre.
        /// </summary>
        /// <param name="nuevoUsuario">
        /// Usuario que se desea registrar.
        /// </param>
        public static void AñadirUsuario(Usuario nuevoUsuario)
        {
            if (usuarios.Any(u => string.Equals(u.Nombre, nuevoUsuario.Nombre, StringComparison.InvariantCultureIgnoreCase)))
            {
                return;
            }

            usuarios.Add(nuevoUsuario);
        }

        /// <summary>
        /// Añade un nuevo ítem al sistema si no existe previamente
        /// un ítem equivalente.
        /// </summary>
        /// <param name="nuevoItem">
        /// Ítem que se desea agregar.
        /// </param>
        public static void AñadirItem(IItem nuevoItem)
        {
            foreach (IItem item in items)
            {
                if (item.Equals(nuevoItem))
                {
                    return;
                }
            }

            items.Add(nuevoItem);
        }

        /// <summary>
        /// Registra una nueva interacción entre un usuario y un ítem,
        /// siempre que ambos existan en el sistema y que la interacción
        /// no haya sido registrada previamente.
        /// </summary>
        /// <param name="nuevaInteraccion">
        /// Interacción que se desea agregar.
        /// </param>
        public static void AñadirInteraccion(Interaccion nuevaInteraccion)
        {
            if (!(usuarios.Contains(nuevaInteraccion.Usuario) && items.Contains(nuevaInteraccion.Item)))
            {
                return;
            }

            foreach (Interaccion interaccion in interacciones)
            {
                if (interaccion.Equals(nuevaInteraccion))
                {
                    return;
                }
            }

            interacciones.Add(nuevaInteraccion);
        }

        /// <summary>
        /// Obtiene un ranking de ítems ordenados según
        /// la cantidad de interacciones registradas.
        /// </summary>
        /// <returns>
        /// Lista de ítems ordenados por popularidad.
        /// </returns>
        public static List<IItem> RankingPorInteracciones()
        {
            motor = new Motor();

            List<IItem> resultado = motor.RankingInteracciones(items, interacciones);

            return resultado;
        }

        /// <summary>
        /// Obtiene un ranking de ítems recomendado para un usuario
        /// en función de sus gustos y disgustos.
        /// </summary>
        /// <param name="usuario">
        /// Usuario para el cual se desea generar el ranking.
        /// </param>
        /// <returns>
        /// Lista de ítems recomendados para el usuario.
        /// Devuelve null si el usuario no existe en el sistema.
        /// </returns>
        public static List<IItem> RankingPorPreferencia(Usuario usuario)
        {
            if (!usuarios.Contains(usuario))
            {
                return null;
            }

            motor = new Motor();

            List<IItem> resultado = motor.RankingPreferencias(items, usuario.Gustos, usuario.Disgustos);

            return resultado;
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
        public static Usuario GetUsuario(string nombre)
        {
            Usuario resultado = null;

            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Nombre.Equals(nombre, StringComparison.InvariantCultureIgnoreCase))
                {
                    resultado = usuario;
                    break;
                }
            }

            return resultado;
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
        public static IItem GetItem(string nombre)
        {
            IItem resultado = null;

            foreach (IItem item in items)
            {
                if (item.Nombre == nombre)
                {
                    resultado = item;
                    break;
                }
            }

            return resultado;
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
        public static Interaccion GetInteraccion(Usuario usuario, IItem item)
        {
            Interaccion resultado = null;

            foreach (Interaccion interaccion in interacciones)
            {
                if (interaccion.Usuario.Equals(usuario) && interaccion.Item.Equals(item))
                {
                    resultado = interaccion;
                    break;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Obtiene la colección de usuarios registrados.
        /// </summary>
        /// <returns>
        /// Lista de usuarios del sistema.
        /// </returns>
        public static List<Usuario> GetUsuarios()
        {
            return usuarios;
        }

        /// <summary>
        /// Obtiene la colección de interacciones registradas.
        /// </summary>
        /// <returns>
        /// Lista de interacciones del sistema.
        /// </returns>
        public static List<Interaccion> GetInteracciones()
        {
            return interacciones;
        }

        /// <summary>
        /// Obtiene la colección de ítems disponibles.
        /// </summary>
        /// <returns>
        /// Lista de ítems del sistema.
        /// </returns>
        public static List<IItem> GetItems()
        {
            return items;
        }
    }
}
