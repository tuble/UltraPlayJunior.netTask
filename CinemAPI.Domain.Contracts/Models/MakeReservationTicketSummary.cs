using CinemAPI.Models.Contracts.ReservationTicket;

namespace CinemAPI.Domain.Contracts.Models
{
    public class MakeReservationTicketSummary
    {
        public MakeReservationTicketSummary(bool isValid)
        {
            this.isValid = isValid;
        }

        public MakeReservationTicketSummary(bool isValid, IReservationTicket reservationObj)
        {
            this.isValid = isValid;
            Reservation = reservationObj;
        }

        public MakeReservationTicketSummary(bool status, string msg)
            : this(status)
        {
            this.Message = msg;
        }

        public string Message { get; set; }

        public IReservationTicket Reservation { get; set; }
        public bool isValid { get; set; }
    }
}