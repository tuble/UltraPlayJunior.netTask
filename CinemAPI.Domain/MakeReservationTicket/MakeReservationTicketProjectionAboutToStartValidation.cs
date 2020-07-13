using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.ReservationTicket;
using System;

namespace CinemAPI.Domain
{
    public class MakeReservationTicketProjectionAboutToStartValidation : IMakeReservationTicket
    {
        private readonly IReservationTicketRepository ticketsRepo;
        private readonly IMakeReservationTicket ticket;

        public MakeReservationTicketProjectionAboutToStartValidation(IReservationTicketRepository ticketsRepo, IMakeReservationTicket ticket)
        {
            this.ticketsRepo = ticketsRepo;
            this.ticket = ticket;
        }

        public MakeReservationTicketSummary Make(IReservationCreation ticket)
        {
            // global constant for timespan
            if (ticketsRepo.TicketStartTime(ticket.ProjId) - DateTime.Now <= new TimeSpan(0, 10, 0))
            {
                return new MakeReservationTicketSummary(false, $"Can't make reservation. Projection {ticket.ProjId} is about to start.");
            }

            return new MakeReservationTicketSummary(true, ticketsRepo.MakeReservation(ticket));
        }
    }
}