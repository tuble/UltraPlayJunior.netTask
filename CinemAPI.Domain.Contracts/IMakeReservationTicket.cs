using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.ReservationTicket;

namespace CinemAPI.Domain.Contracts
{
    public interface IMakeReservationTicket
    {
        MakeReservationTicketSummary Make(IReservationCreation ticketParams);
    }
}
