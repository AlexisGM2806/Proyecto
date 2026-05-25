using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Motor
    {
        public List<IItem> RankingPreferencias(List<IItem> items, IPreferencia gustos, IPreferencia disgusto)
        {
            if (gustos == null || disgusto == null)
            {
                return null;
            }
            
            List<IItem> resultado = new List<IItem>();

            foreach (IItem item in items)
            {
                int positivo = gustos.ValorarItem(item);
                int negativo = disgusto.ValorarItem(item);
                int valor = positivo + negativo;
                if (valor > 0)
                {
                    resultado.Add(item);
                }
            }
            
            return resultado.OrderByDescending(i => (gustos.ValorarItem(i)-disgusto.ValorarItem(i))).ToList();
        }

        public List<IItem> RankingInteracciones(List<IItem> items, List<Interaccion> interacciones, bool incluirConsumidos = true)
        {
            List<IItem> resultado = new List<IItem>();

            resultado = items.OrderByDescending(i => (interacciones.Count(x => x.Item.Equals(i)))).ToList();
            
            return resultado;
        }

    }
}
