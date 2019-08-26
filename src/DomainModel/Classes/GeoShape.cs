namespace DomainModel.Classes
{
    public class GeoShape
    {
        /// <summary>
        /// Rappresenta l'Id in MongoDB
        /// </summary>
        public string Id { get; protected set; }

        /// <summary>
        /// Contiene la descrizione del punto d'interesse da restituire in caso di matching
        /// </summary>
        public string ObjectDesc { get; set; }

        /// <summary>
        /// Contiene l'identificativo del database sorgente
        /// </summary>
        public string SourceCode { get; set; }

        /// <summary>
        /// Rappresenta la distaza calcolata rispetto alle coordinate iniziali
        /// </summary>
        public Distance Dist { get; set; }

    }
}
