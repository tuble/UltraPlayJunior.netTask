using CinemAPI.Data.EF;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.ReservationTicket;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemAPI.Data.Implementation
{
    public class ReservationTicketRepository : IReservationTicketRepository
    {
        private readonly CinemaDbContext db;

        public ReservationTicketRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public bool SeatTaken(int row, int col)
        {
            // if not null => Taken
            return db.ReservationTickets.FirstOrDefault((x) => x.SeatRow == row && x.SeatCol == col) != null;
        }
        public int RoomSeatsPerRow(long projId)
        {
            var prj = db.Projections.FirstOrDefault((p) => p.Id == projId);
            var room = db.Rooms.FirstOrDefault((r) => r.Id == prj.RoomId);

            return room.SeatsPerRow;
        }
        public int RoomRows(long projId)
        {
            var prj = db.Projections.FirstOrDefault((p) => p.Id == projId);
            var room = db.Rooms.FirstOrDefault((r) => r.Id == prj.RoomId);

            return room.Rows;
        }
        public DateTime TicketStartTime(long projId)
        {
            return db.Projections.FirstOrDefault((x) => x.Id == projId).StartDate;
        }

        public IReservationTicket MakeReservation(IReservationCreation reservation)
        {
            ReservationTicket reservationTicket = new ReservationTicket(reservation.ProjId, reservation.SeatRow,
                reservation.SeatCol);

            reservationTicket.Projection = db.Projections.FirstOrDefault((p) => p.Id == reservation.ProjId);
            reservationTicket.Projection.Movie = db.Movies.FirstOrDefault((m) => m.Id == reservationTicket.Projection.MovieId);
            reservationTicket.Projection.Room = db.Rooms.FirstOrDefault((r) => r.Id == reservationTicket.Projection.RoomId);
            reservationTicket.Projection.Room.Cinema = db.Cinemas.FirstOrDefault(
                (c) => c.Id == reservationTicket.Projection.Room.CinemaId);

            --reservationTicket.Projection.AvailableSeatsCount;

            db.ReservationTickets.Add(reservationTicket);
            db.SaveChanges();

            return new MakeReservationTicket(reservationTicket.Id, reservationTicket.Projection.StartDate,
                reservationTicket.Projection.Movie.Name, reservationTicket.Projection.Room.Cinema.Name,
                reservationTicket.Projection.Room.Number, reservationTicket.SeatRow, reservationTicket.SeatCol);
        }
    }
}