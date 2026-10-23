using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
    public class PSG_vs_AC_MilanModel : PageModel
    {
        private readonly EventsInfoDbContext _db;

        public PSG_vs_AC_MilanModel(EventsInfoDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public EventList TheeventList { get; set; }

        public void OnGet()
        {
            TheeventList = _db.EventsTable.FirstOrDefault(e => e.Id == 3);
        }

        public IActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newEvent = new EventList
                    {
                        EventName = TheeventList.EventName,
                        Description = TheeventList.Description,
                        Day = TheeventList.Day,
                        Venue = TheeventList.Venue,
                        Title = TheeventList.Title,
                        imageurl = TheeventList.imageurl
                    };

                    _db.EventsTable.Add(newEvent);
                    _db.SaveChanges();
                    return RedirectToPage("/Index");
                }
                else
                {
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while saving the data.");
                return Page();
            }
        }
    }
}
