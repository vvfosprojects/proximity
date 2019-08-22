using DomainModel.Classes;
using MongoDB.Bson;

namespace DomainModel.CQRS.Queries.GetClosePoints
{
    public class GetClosePointsQueryResult 
    {
        /// <summary>
        /// Rappresenta l'insieme dei punti che soddisfano il criterio di ricerca
        /// </summary>
        public BsonDocument GeoShapes { get; set; }
    }
}
