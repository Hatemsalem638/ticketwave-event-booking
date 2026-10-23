using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages.Admin
{
    public class AddEventsModel : PageModel
    {

        public EventsInfoDbContext _db { get; set; }

        public AddEventsModel(EventsInfoDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public EventList TheEventList { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _db.EventsTable.Add(TheEventList);
            _db.SaveChanges();
            return RedirectToPage("ViewEvents");
        }
    }
}
