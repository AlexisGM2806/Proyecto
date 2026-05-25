using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    /// <summary>
    /// Representa el motor encargado de generar rankings
    /// y recomendaciones de ítems dentro del sistema.
    /// </summary>
    public class Motor
    {
        /// <summary>
        /// Genera un ranking de ítems en base a los gustos
        /// y disgustos especificados.
        /// </summary>
        /// <param name="items">Colección de ítems a evaluar.</param>
        /// <param name="gustos">Preferencias positivas utilizadas para la valoración.</param>
        /// <param name="disgusto">Preferencias negativas utilizadas para la valoración.</param>
        /// <returns>
        /// Lista de ítems ordenados según su afinidad total,
        /// excluyendo aquellos cuya valoración final no sea positiva.
        /// Devuelve null si alguna de las preferencias es null.
        /// </returns>
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
            
            return resultado
                .OrderByDescending(i => (gustos.ValorarItem(i) - disgusto.ValorarItem(i)))
                .ToList();
        }

        /// <summary>
        /// Genera un ranking de ítems en función de la cantidad
        /// de interacciones registradas para cada uno.
        /// </summary>
        /// <param name="items">Colección de ítems a ordenar.</param>
        /// <param name="interacciones">
        /// Lista de interacciones utilizadas para calcular popularidad o consumo.
        /// </param>
        /// <param name="incluirConsumidos">
        /// Indica si deben incluirse ítems ya consumidos dentro del ranking.
        /// </param>
        /// <returns>
        /// Lista de ítems ordenados de forma descendente
        /// según la cantidad de interacciones asociadas.
        /// </returns>
        public List<IItem> RankingInteracciones(List<IItem> items, List<Interaccion> interacciones, bool incluirConsumidos = true)
        {
            List<IItem> resultado = new List<IItem>();

            resultado = items
                .OrderByDescending(i => (interacciones.Count(x => x.Item.Equals(i))))
                .ToList();
            
            return resultado;
        }
    }
}
