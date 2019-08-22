using System;
using SimpleInjector;

namespace CompositionRoot
{
    /// <summary>
    /// This class contains all the custom application bindings.
    /// </summary>
    internal static class CustomBindings
    {
        internal static void Bind(Container container)
        {
            BindDB_MongoDb(container);
        }

        private static void BindDB_MongoDb(Container container)
        {
            container.Register<DomainModel.Services.IGetClosePoints, Persistence.MongoDB.GetClosePoints>();

            container.Register<Persistence.MongoDB.DbContext>(() =>
            {
                return new Persistence.MongoDB.DbContext(@"mongodb://localhost:27017/GeoLoc");
            }, Lifestyle.Singleton);
        }
    }
}