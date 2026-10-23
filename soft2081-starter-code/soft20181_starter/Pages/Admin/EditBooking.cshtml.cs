using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;
using System.Collections.Generic;
using System.Linq;

namespace soft20181_starter.Pages.Admin
{
    public class EditBookingModel : PageModel
    {
        private readonly EventsInfoDbContext _db;

        public EditBookingModel(EventsInfoDbContext db)
        {
            _db = db;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public AttendaceList TheAttendaceList { get; set; }

        public List<string> EventNames { get; set; }

        public IActionResult OnGet()
        {
            // Populate the dropdown list with event names from the EventsTable
            EventNames = _db.EventsTable.Select(e => e.EventName).ToList();

            // Fetch the attendance list based on the provided Id
            TheAttendaceList = _db.AttendaceTable.Find(Id);

            return Page();
        }

        public IActionResult OnGetDelete()
        {
            TheAttendaceList = _db.AttendaceTable.Find(Id);
            _db.AttendaceTable.Remove(TheAttendaceList);
            _db.SaveChanges();
            return RedirectToPage("BookingInfo");
        }

        public IActionResult OnPost()
        {
            _db.AttendaceTable.Update(TheAttendaceList);
            _db.SaveChanges();
            return RedirectToPage("BookingInfo");
        }
    }
}
