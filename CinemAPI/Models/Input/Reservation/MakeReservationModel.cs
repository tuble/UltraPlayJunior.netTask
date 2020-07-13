using System;

namespace CinemAPI.Models.Input.Reservation
{
    public class MakeReservationModel
    {
        public long ProjId { get; set; }

        public int SeatRow { get; set; }
        public int SeatCol { get; set; }

    }
}