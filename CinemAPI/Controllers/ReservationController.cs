using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Input.Reservation;
using System.Web.Http;


namespace CinemAPI.Controllers
{
    public class ReservationController : ApiController
    {
        private readonly IMakeReservationTicket newTicket;

        public ReservationController(IMakeReservationTicket newTicket)
        {
            this.newTicket = newTicket;
        }

        [HttpPost]
        public IHttpActionResult Make([FromUri] MakeReservationModel reservationModel)
        {
            MakeReservationTicketSummary summary = newTicket.Make(new ReservationTicketCreation(reservationModel.ProjId,
                reservationModel.SeatRow, reservationModel.SeatCol));

            if (summary.isValid)
            {
                return Ok(summary.Reservation);
            }

            return BadRequest(summary.Message);
        }
    }
}