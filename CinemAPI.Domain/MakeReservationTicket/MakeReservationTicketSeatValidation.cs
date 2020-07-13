using CinemAPI.Data;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.ReservationTicket;

namespace CinemAPI.Domain
{
    public class MakeReservationTicketSeatValidation : Contracts.IMakeReservationTicket
    {
        private readonly IReservationTicketRepository ticketsRepo;
        private readonly Contracts.IMakeReservationTicket ticket;


        public MakeReservationTicketSeatValidation(IReservationTicketRepository ticketsRepo, Contracts.IMakeReservationTicket ticket)
        {
            this.ticketsRepo = ticketsRepo;
            this.ticket = ticket;
        }

        public MakeReservationTicketSummary Make(IReservationCreation ticket)
        {
            int roomRows = ticketsRepo.RoomRows(ticket.ProjId);
            int roomCols = ticketsRepo.RoomSeatsPerRow(ticket.ProjId);

            if (ticketsRepo.SeatTaken(ticket.SeatRow, ticket.SeatCol))
            {
                return new MakeReservationTicketSummary(false, $"Can't make reservation. Seat at {ticket.SeatRow} {ticket.SeatCol} is taken.");
            }

            if (ticket.SeatCol <= 0 || ticket.SeatCol > roomCols || ticket.SeatRow <= 0 || ticket.SeatRow > roomRows)
            {
                return new MakeReservationTicketSummary(false, $"Can't make reservation. Seat at {ticket.SeatRow} {ticket.SeatCol} doesn't exist.");
            }

            return new MakeReservationTicketSummary(true, ticketsRepo.MakeReservation(ticket));
        }
    }
}