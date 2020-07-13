using CinemAPI.Models.Contracts.Projection;
using System;

namespace CinemAPI.Models
{
    public class ProjectionAvailableSeats : IProjectionGetAvailableSeats
    {
        public ProjectionAvailableSeats()
        { }

        public ProjectionAvailableSeats(long projId)
        {
            this.Id = projId;
        }

        public long Id { get; set; }

    }
}