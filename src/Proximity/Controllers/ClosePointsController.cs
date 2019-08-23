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