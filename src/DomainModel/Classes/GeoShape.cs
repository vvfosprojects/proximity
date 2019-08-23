namespace DomainModel.Classes
{
    public class GeoShape
    {
        public string Id { get; protected set; }

        public string ObjectDesc { get; set; }

        public string SourceCode { get; set; }

        public bool Attivo { get; set; }

        //public GeoShapeGeometry Geometry { get; set; }
    }
}
