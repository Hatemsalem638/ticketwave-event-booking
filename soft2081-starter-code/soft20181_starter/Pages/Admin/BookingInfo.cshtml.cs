using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages.Admin
{
    public class BookingInfoModel : PageModel
    {
        public EventsInfoDbContext _db { get; set; }

        public BookingInfoModel(EventsInfoDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public AttendaceList TheAttendaceList { get; set; }

        public List<AttendaceList> TheListofAttendance { get; set; }
        public void OnGet()
        {
            TheListofAttendance = _db.AttendaceTable.ToList();
        }
    }
}
