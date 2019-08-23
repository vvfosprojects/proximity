using DomainModel.Classes;
using DomainModel.CQRS.Queries.GetClosePoints;
using DomainModel.Services;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
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
            //var collection = dbContext.GeoShapeCollection.Find(_ => true).ToList();

            var collection = dbContext.GeoShapeCollection;

            //var index = collection.Indexes.CreateOne(new IndexKeysDefinitionBuilder<BsonDocument>().Geo2DSphere());
            //collection.Indexes.CreateOne(new IndexKeysDefinitionBuilder<BsonDocument>().Geo2DSphere(x => x.Geometry));

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


            //List<BsonDocument> list = collection.Find(filter).ToList();
            //var jsons = list.Select(bdoc => bdoc.ToJson());

            List<GeoShape> list = collection.Find(filter).ToList();


            return new GetClosePointsQueryResult()
            {
                GeoShapes = list
            };
        }
    }
}
