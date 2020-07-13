using System;

namespace CinemAPI.Models.Contracts.ReservationTicket
{
    public interface IReservationTicket
    {
        int Id { get; }
        DateTime ProjectionStartDate { get; }
        string MovieName { get; }
        string CinemaName { get; }
        int RoomNumber { get; }
        int SeatRow { get; }
        int SeatCol { get; }

    }
}
