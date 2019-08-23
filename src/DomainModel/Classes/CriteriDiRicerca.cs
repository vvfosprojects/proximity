using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Classes
{
    public class CriteriDiRicerca
    {
        /// <summary>
        /// Rappresenta la latitudine del punto da utilizzare per la ricerca
        /// </summary>
        public double Latitudine { get; set; }

        /// <summary>
        /// Rappresenta la longitudine del punto da utilizzare per la ricerca
        /// </summary>
        public double Longitudine { get; set; }

        /// <summary>
        /// Rappresenta la distanza nella quale devono essere ricercati i punti a partire dalle coordinate immesse
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// Rappresenta la pagina da visuallizare contenente i punti ottenuti tramite la ricerca ricerca
        /// </summary>
        public int Page { get; set; }
    }
}