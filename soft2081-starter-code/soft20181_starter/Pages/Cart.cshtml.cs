using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;
using System.Linq;

namespace soft20181_starter.Pages
{
    public class CartModel : PageModel
    {
        private readonly EventsInfoDbContext _db;

        public CartModel(EventsInfoDbContext db)
        {
            _db = db;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public List<AttendaceList> CartItems { get; set; }

        public AttendaceList TheAttendaceList { get; set; }

        public void OnGet()
        {
            // Retrieve items from the cart (AttendanceTable)
            CartItems = _db.AttendaceTable.ToList();
            TheAttendaceList = _db.AttendaceTable.Find(Id);
        }

        public IActionResult OnGetDelete()
        {
            var itemToRemove = _db.AttendaceTable.Find(Id);
            if (itemToRemove == null)
            {
                return NotFound();
            }

            _db.AttendaceTable.Remove(itemToRemove);
            _db.SaveChanges();
            return RedirectToPage("/Cart");
        }
    }
}
