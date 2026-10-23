namespace soft20181_starter.Models
{
    public class AttendaceList
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string EventTicket { get; set; }
    }
}
