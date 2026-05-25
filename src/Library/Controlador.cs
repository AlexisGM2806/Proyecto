using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Controlador
    {
        private static List<Usuario> usuarios;
        private static List<IItem> items;
        private static List<Interaccion> interacciones;

        private static Motor motor;
            
        public static void Inicializar (List<Usuario> usuariosIniciales, List<IItem> itemsIniciales, List<Interaccion> interaccionesIniciales)
        {
            usuarios = usuariosIniciales;
            items = itemsIniciales;
            interacciones = interaccionesIniciales;
        }
        
        public static void AñadirUsuario (Usuario nuevoUsuario)
        {
            if (usuarios.Any(u => string.Equals(u.Nombre, nuevoUsuario.Nombre, StringComparison.InvariantCultureIgnoreCase)))
            {
                return;
            }

            usuarios.Add(nuevoUsuario);
        }

        public static void AñadirItem (IItem nuevoItem)
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

        public static void AñadirInteraccion (Interaccion nuevaInteraccion)
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

        public static List<IItem> RankingPorInteracciones()
        {
            motor = new Motor();

            List<IItem> resultado = motor.RankingInteracciones(items,interacciones);

            return resultado; 
        }

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

        public static List<Usuario> GetUsuarios()
        {
            return usuarios;
        }

        public static List<Interaccion> GetInteracciones()
        {
            return interacciones;
        }

        public static List<IItem> GetItems()
        {
            return items;
        }

    }
}
