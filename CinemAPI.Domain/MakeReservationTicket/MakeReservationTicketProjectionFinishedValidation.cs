using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.ReservationTicket;
using System;

namespace CinemAPI.Domain
{
    public class MakeReservationTicketProjectionFinishedValidation : IMakeReservationTicket
    {
        private readonly IReservationTicketRepository ticketsRepo;
        private readonly Contracts.IMakeReservationTicket ticket;

        public MakeReservationTicketProjectionFinishedValidation(IReservationTicketRepository ticketsRepo, Contracts.IMakeReservationTicket ticket)
        {
            this.ticket = ticket;
            this.ticketsRepo = ticketsRepo;
        }

        public MakeReservationTicketSummary Make(IReservationCreation ticket)
        {
            if (DateTime.Compare(ticketsRepo.TicketStartTime(ticket.ProjId), DateTime.Now) < 0)
            {
                return new MakeReservationTicketSummary(false, $"Can't make reservation. Projection {ticket.ProjId} has already started.");

            }

            return new MakeReservationTicketSummary(true, ticketsRepo.MakeReservation(ticket));
        }
    }
}