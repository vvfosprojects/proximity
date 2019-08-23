
using DomainModel.Classes;
using System.Collections.Generic;

namespace DomainModel.CQRS.Queries.GetClosePoints
{
    public class GetClosePointsQueryResult
    {
        /// <summary>
        /// Rappresenta l'insieme dei punti che soddisfano il criterio di ricerca
        /// </summary>
        public List<GeoShape> GeoShapes { get; set; }
    }
}
