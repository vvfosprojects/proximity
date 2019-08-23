using DomainModel.Classes;
using DomainModel.CQRS.Queries.GetClosePoints;
using DomainModel.Services;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;


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
            var collection = dbContext.GeoShapeCollection;

            var filter = new BsonDocument
            {
                { "geometry", new BsonDocument {
                    { "$nearSphere", new BsonDocument {
                        { "$geometry", new BsonDocument {
                            { "type", "Point" },
                            { "coordinates", new BsonArray { query.Latitudine, query.Longitudine } },
                            }
                        },
                        { "$maxDistance", query.Distance }
                    }
                    }
                }
                }
            };

            List<GeoShape> list = collection.Find(filter).ToList();

            return new GetClosePointsQueryResult()
            {
                GeoShapes = list
            };
        }
    }
}
