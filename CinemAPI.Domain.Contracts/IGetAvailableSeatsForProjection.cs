using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Projection;

namespace CinemAPI.Domain.Contracts
{
    public interface IGetAvailableSeatsForProjection
    {
        GetAvailableSeatsForProjectionSummary Get(IProjectionGetAvailableSeats seats);
    }
}
