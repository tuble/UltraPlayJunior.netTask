using CinemAPI.Models.Contracts.ReservationTicket;
using System;

namespace CinemAPI.Models
{
    public class ReservationTicketCreation : IReservationCreation
    {
        public ReservationTicketCreation()
        { }

        public ReservationTicketCreation(long projId, int row, int col)
        {
            this.ProjId = projId;
            this.SeatRow = row;
            this.SeatCol = col;
        }

        public long ProjId { get; set; }
        public virtual Projection Projection { get; set; }
        public int SeatRow { get; set; }
        public int SeatCol { get; set; }
    }
}
