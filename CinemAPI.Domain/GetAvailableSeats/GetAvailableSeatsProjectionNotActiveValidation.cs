using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Projection;

namespace CinemAPI.Domain
{
    public class GetAvailableSeatsProjectionNotActiveValidation : IGetAvailableSeatsForProjection
    {
        private readonly IProjectionRepository projectionsRepo;

        public GetAvailableSeatsProjectionNotActiveValidation(IProjectionRepository projectionsRepo)
        {
            this.projectionsRepo = projectionsRepo;
        }
        public GetAvailableSeatsForProjectionSummary Get(IProjectionGetAvailableSeats proj)
        {

            if (!projectionsRepo.ProjectionExists(proj.Id))
            {
                return new GetAvailableSeatsForProjectionSummary(false, $"Projection with id {proj.Id} doesn't exist!");
            }

            if (projectionsRepo.IsProjectionActive(proj.Id))
            {
                return new GetAvailableSeatsForProjectionSummary(false, $"Projection with id {proj.Id} is currently active!");
            }

            return new GetAvailableSeatsForProjectionSummary(true, projectionsRepo.GetAvailableSeatsForProjection(proj.Id));

        }

    }
}