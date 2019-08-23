using CQRS.Queries;
using DomainModel.Services;
using System;


namespace DomainModel.CQRS.Queries.GetClosePoints
{
    public class GetClosePointsHandler : IQueryHandler <GetClosePointsQuery, GetClosePointsQueryResult>
    {
        private readonly IGetClosePoints getClosePoints;

        public GetClosePointsHandler(IGetClosePoints getClosePoints)
        {
            this.getClosePoints = getClosePoints ?? throw new ArgumentNullException(nameof(getClosePoints));
        }

        public GetClosePointsQueryResult Handle (GetClosePointsQuery query)
        {
            return new GetClosePointsQueryResult()
            {
                GeoShapes = this.getClosePoints.Get(query).GeoShapes
            };
        }
    }
}
