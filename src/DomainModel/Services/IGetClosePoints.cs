using DomainModel.CQRS.Queries.GetClosePoints;


namespace DomainModel.Services
{
    public interface IGetClosePoints
    {
        GetClosePointsQueryResult Get(GetClosePointsQuery query);
    }
}
