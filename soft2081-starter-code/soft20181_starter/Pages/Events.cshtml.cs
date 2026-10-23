using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;
using System.Collections.Generic;
using System.Linq;

namespace soft20181_starter.Pages
{
    public class EventsModel : PageModel
    {
        private readonly EventsInfoDbContext _db;

        public EventsModel(EventsInfoDbContext db)
        {
            _db = db;
        }

        public List<EventList> EventList { get; set; }

        // Mapping of event IDs to image URLs and detail page URLs
        public Dictionary<int, (string ImageUrl, string DetailPageUrl)> EventUrlMappings { get; } = new Dictionary<int, (string, string)>
        {
            { 1, ("/css/Madrid vs napoli.jpg", "Real Madrid vs Napoli") },
            { 2, ("/css/Liverpool-vs-Manchester-United-min.jpg", "Liverpool vs Manchester United") },
            { 3, ("/css/PSG-vs-Milan.jpg", "PSG vs AC Milan") },
            { 4, ("/css/Barcelona vs atletico.jpg", "Barcelona vs Atletico Madrid") },
            { 5, ("/css/Lakers vs magic.jpg", "Lakers ss magic") },
            { 6, ("/css/Cavaliers vs Knicks.jpg", "Cavaliers vs Knicks") },
            { 7, ("/css/isle 2024.jpg", "Isle of Wight") },
            { 8, ("/css/weeknd.jpg", "The Weeknd") },
            { 9, ("/css/central cee wp.jpg", "Central Cee Concert") },
            { 10, ("/css/Dave wp.jpg", "Dave concert") }
        };

        public void OnGet()
        {
            EventList = _db.EventsTable.ToList();

            foreach (var eventItem in EventList)
            {
                // Temporary variables to hold URL information
                string imageUrl;
                string detailPageUrl;

                // Check if the event ID exists in the mapping
                if (EventUrlMappings.ContainsKey(eventItem.Id))
                {
                    // Retrieve the URLs from the mapping
                    var urls = EventUrlMappings[eventItem.Id];
                    imageUrl = urls.ImageUrl;
                    detailPageUrl = urls.DetailPageUrl;
                }
                else
                {
                    // Use default URLs if no mapping is found
                    imageUrl = "~/css/default_image.png"; // Or any default image URL
                    detailPageUrl = "DefaultPage"; // Or any default detail page URL
                }

                // Here you can use imageUrl and detailPageUrl as needed
                // For example, you can create hyperlinks with these URLs
                // However, since I'm not modifying the HTML part, I'll leave it to you to integrate these URLs into your HTML
            }
            
        }
    }
}
