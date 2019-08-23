using DomainModel.CQRS.Queries.GetClosePoints;


namespace DomainModel.Services
{
    public interface IGetClosePoints
    {
        /// <summary>
        /// Il metodo, preso in input le due coordinate Latitudine e Longitudine e una distanza, ricerca 
        /// punti d'interesse che ricadono all'interno dell'area "disegnata" 
        /// </summary>

        GetClosePointsQueryResult Get(GetClosePointsQuery query);
    }
}
