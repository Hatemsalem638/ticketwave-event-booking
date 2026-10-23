using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages.Admin
{
    public class EditEventsModel : PageModel
    {

        public EventsInfoDbContext _db { get; set; }

        public EditEventsModel(EventsInfoDbContext db)
        {
            _db = db;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public EventList TheEventList { get; set; }

        public void OnGet()
        {
            TheEventList = _db.EventsTable.Find(Id);

        }
        public IActionResult OnGetDelete()
        {
            TheEventList = _db.EventsTable.Find(Id);
            _db.EventsTable.Remove(TheEventList);
            _db.SaveChanges();
            return RedirectToPage("ViewEvents");
        }
        public IActionResult OnPost()
        {
            _db.EventsTable.Update(TheEventList);
            _db.SaveChanges();
            return RedirectToPage("ViewEvents");
        }
    }
}
