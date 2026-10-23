using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages.Admin
{
    public class ViewEventsModel : PageModel
    {
        public EventsInfoDbContext _db { get; set; }

        public ViewEventsModel(EventsInfoDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public EventList TheEventList { get; set; }

        public List<EventList> EventListed { get; set; }
        public void OnGet()
        {
            EventListed = _db.EventsTable.ToList();
        }
    }
}
