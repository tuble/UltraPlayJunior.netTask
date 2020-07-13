using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Input.Projection;
using System.Web.Http;

namespace CinemAPI.Controllers
{
    public class ProjectionController : ApiController
    {
        private readonly INewProjection newProj;

        private readonly IGetAvailableSeatsForProjection allSeats;

        public ProjectionController(INewProjection newProj, IGetAvailableSeatsForProjection allSeats)
        {
            this.newProj = newProj;
            this.allSeats = allSeats;
        }

        public IHttpActionResult Index(ProjectionCreationModel model)
        {
            NewProjectionSummary summary = newProj.New(
                new Projection(model.MovieId, model.RoomId, model.StartDate, model.AvailableSeatsCount));

            if (summary.IsCreated)
            {
                return Ok();
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetAvailableSeatsForProjection([FromUri] ProjectionGetAvailableSeatsModel projectionModel)
        {
            GetAvailableSeatsForProjectionSummary summary = allSeats.Get(new ProjectionAvailableSeats(projectionModel.Id));

            if (summary.isValid)
            {
                return Ok(summary.availableSeats);
            }

            return BadRequest(summary.Message);

        }
    }
}