using System;

namespace CinemAPI.Models.Contracts.ReservationTicket
{
    public interface IReservationCreation
    {
        long ProjId { get; }
        int SeatRow { get; }
        int SeatCol { get; }


    }
}
