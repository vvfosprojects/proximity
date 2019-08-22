using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Classes
{
    public class GeoShape
    {
        public GeoShape()
        { }

        public string Id { get; protected set; }

        public string Type { get; set; }

        public GeoShapeProperties Properties {get; set;}

        public GeoShapeGeometry Geometry { get; set; }
    }
}
