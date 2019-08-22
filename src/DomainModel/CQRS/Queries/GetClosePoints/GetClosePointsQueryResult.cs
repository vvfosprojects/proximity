using DomainModel.Classes;

namespace DomainModel.CQRS.Queries.GetClosePoints
{
    public class GetClosePointsQueryResult 
    {
        /// <summary>
        /// Rappresenta l'insieme dei punti che soddisfano il criterio di ricerca
        /// </summary>
        public GeoShape[] GeoShape { get; set; }
    }
}
