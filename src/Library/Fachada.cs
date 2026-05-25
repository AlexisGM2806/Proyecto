using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Fachada
    {
        public void AñadirUsuario (Usuario nuevoUsuario)
        {
            Controlador.AñadirUsuario(nuevoUsuario);
        }

        public void AñadirItem (IItem nuevoItem)
        {
            Controlador.AñadirItem(nuevoItem);
        }

        public void AñadirInteraccion (Interaccion nuevaInteraccion)
        {
            Controlador.AñadirInteraccion(nuevaInteraccion);
        }

        public List<IItem> RankingPorInteracciones()
        {
            return Controlador.RankingPorInteracciones(); 
        }

        public List<IItem> RankingPorPreferencia(Usuario usuario)
        {
            return Controlador.RankingPorPreferencia(usuario);
        }

        public Usuario GetUsuario(string nombre)
        {
            return Controlador.GetUsuario(nombre);
        }

        public IItem GetItem(string nombre)
        {
            return Controlador.GetItem(nombre);
        }

        public Interaccion GetInteraccion(Usuario usuario, IItem item)
        {
            return Controlador.GetInteraccion(usuario, item);
        }

        public List<Usuario> GetUsuarios()
        {
            return Controlador.GetUsuarios();
        }

        public List<Interaccion> GetInteracciones()
        {
            return Controlador.GetInteracciones();
        }

        public List<IItem> GetItems()
        {
            return Controlador.GetItems();
        }

    }
}
