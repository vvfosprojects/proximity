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

            /*
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
            */




            var filter = new BsonDocument
            {
                    { "near", new BsonDocument {
                        {"type", "Point"}, { "coordinates", new BsonArray { query.Latitudine, query.Longitudine }} }},
                        { "distanceField", "dist.calculated"},
                        { "maxDistance", query.Distance},
                        { "sperical", true }
                };

            var pipeline = new[] {
                new BsonDocument { { "$geoNear", filter } }
            };

            List<GeoShape> list = collection.Aggregate<GeoShape>(pipeline).ToList();

            return new GetClosePointsQueryResult()
            {
                GeoShapes = list
            };
        }
    }
}
