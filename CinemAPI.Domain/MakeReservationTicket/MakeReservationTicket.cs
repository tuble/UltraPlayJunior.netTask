using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.ReservationTicket;

namespace CinemAPI.Domain
{
    public class MakeReservationTicket : IMakeReservationTicket
    {
        private readonly IReservationTicketRepository ticketsRepo;


        public MakeReservationTicket(IReservationTicketRepository ticketsRepo)
        {
            this.ticketsRepo = ticketsRepo;
        }

        public MakeReservationTicketSummary Make(IReservationCreation ticket)
        {
            return new MakeReservationTicketSummary(true, ticketsRepo.MakeReservation(ticket));
        }
    }
}