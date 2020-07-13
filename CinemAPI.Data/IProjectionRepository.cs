using CinemAPI.Models.Contracts.Projection;
using System;
using System.Collections.Generic;

namespace CinemAPI.Data
{
    public interface IProjectionRepository
    {
        IProjection Get(int movieId, int roomId, DateTime startDate, int availableSeatsCount);

        void Insert(IProjectionCreation projection);

        IEnumerable<IProjection> GetActiveProjections(int roomId);
        bool ProjectionExists(long projectionId);

        bool IsProjectionActive(long projectionId);

        int GetAvailableSeatsForProjection(long projectionId);

    }
}