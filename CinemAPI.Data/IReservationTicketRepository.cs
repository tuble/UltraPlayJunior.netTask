using CinemAPI.Models.Contracts.ReservationTicket;
using System;

namespace CinemAPI.Data
{
    public interface IReservationTicketRepository
    {
        IReservationTicket MakeReservation(IReservationCreation reservation);
        DateTime TicketStartTime(long projId);
        bool SeatTaken(int row, int col);
        int RoomSeatsPerRow(long projId);
        int RoomRows(long projId);

    }
}
