using CinemAPI.Models.Contracts.ReservationTicket;
using System;

namespace CinemAPI.Models
{
    public class ReservationTicket : IReservationCreation
    {
        public ReservationTicket()
        { }

        public ReservationTicket(long projId, int row, int col)
        {
            this.ProjId = projId;
            this.SeatRow = row;
            this.SeatCol = col;
        }

        public int Id { get; set; }

        public long ProjId { get; set; }
        public virtual Projection Projection { get; set; }
        public int SeatRow { get; set; }
        public int SeatCol { get; set; }
    }
}
