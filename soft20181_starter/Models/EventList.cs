namespace soft20181_starter.Models
{
    public class EventList
    {
        public int Id { get; set; }
        public required string EventName { get; set; }
        public required string Description { get; set; }
        public required string Day { get; set; }
        public required string Venue { get; set; }
        public required string Title { get; set; }
        public required string imageurl { get; set;}
        
    }
}
