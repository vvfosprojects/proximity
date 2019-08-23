using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Queries;
using DomainModel.Classes;
using DomainModel.CQRS.Queries.GetClosePoints;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClosePointsController : ControllerBase
    {
        public IQueryHandler<GetClosePointsQuery, GetClosePointsQueryResult> handler { get; }


        public ClosePointsController (IQueryHandler <GetClosePointsQuery, GetClosePointsQueryResult> handler)
        {
            this.handler = handler;
        }

        /// <summary>
        /// Il metodo, preso in input le due coordinate Latitudine e Longitudine e una distanza, ricerca 
        /// punti d'interesse che ricadono all'interno dell'area "disegnata" 
        /// </summary>
        /// <param name="criteri"> Rappresenta il DTO di input con i parametri da utilizzare per la ricerc</param>
        /// <returns>Il metodo ritorna un elenco di punti d'interesse che ricadono all'interno dell'area di ricerca immessa</returns>
        [HttpGet]
        public ActionResult<GetClosePointsQueryResult> Get ([FromQuery] CriteriDiRicerca criteri)
        {
            var query = new GetClosePointsQuery()
            {
                Latitudine = criteri.Latitudine,
                Longitudine = criteri.Longitudine,
                Distance = criteri.Distance,
                Page = criteri.Page
            };

            return Ok(this.handler.Handle(query));
        }
    }
}