namespace CinemAPI.Domain.Contracts.Models
{
    public class GetAvailableSeatsForProjectionSummary
    {
        public GetAvailableSeatsForProjectionSummary(bool isValid)
        {
            this.isValid = isValid;
        }

        public GetAvailableSeatsForProjectionSummary(bool isValid, int availableSeats)
        {
            this.isValid = isValid;
            this.availableSeats = availableSeats;
        }

        public GetAvailableSeatsForProjectionSummary(bool status, string msg)
            : this(status)
        {
            this.Message = msg;
        }

        public string Message { get; set; }

        public bool isValid { get; set; }
        public int availableSeats { get; set; } // cols * rows

    }
}