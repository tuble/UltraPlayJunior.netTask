using CinemAPI.Models.Contracts.ReservationTicket;
using System;

namespace CinemAPI.Models
{
    public class MakeReservationTicket : IReservationTicket
    {
        public MakeReservationTicket()
        { }

        public MakeReservationTicket(int reservationId, DateTime startDate, string movieName, string cinemaName, int roomNum,
            int row, int col)
        {
            this.Id = reservationId;
            this.ProjectionStartDate = startDate;
            this.MovieName = movieName;
            this.CinemaName = cinemaName;
            this.RoomNumber = roomNum;
            this.SeatRow = row;
            this.SeatCol = col;
        }

        public int Id { get; set; }
        public DateTime ProjectionStartDate { get; set; }
        public string MovieName { get; set; }
        public string CinemaName { get; set; }
        public int RoomNumber { get; set; }
        public int SeatRow { get; set; }
        public int SeatCol { get; set; }
    }
}