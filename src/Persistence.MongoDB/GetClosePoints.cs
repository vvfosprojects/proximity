using DomainModel.Classes;
using DomainModel.CQRS.Queries.GetClosePoints;
using DomainModel.Services;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Runtime.CompilerServices;


namespace Persistence.MongoDB
{
    internal class GetClosePoints : IGetClosePoints
    {
        private readonly DbContext dbContext;

        public GetClosePoints(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public GetClosePointsQueryResult Get(GetClosePointsQuery query)
        {
            return new GetClosePointsQueryResult()
            {
            };
        }
    }
}
