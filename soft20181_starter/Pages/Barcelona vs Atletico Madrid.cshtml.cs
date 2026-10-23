using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using soft20181_starter.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace soft20181_starter.Pages
{
    [Authorize]
    public class Barcelona_vs_Atletico_MadridModel : PageModel
    {
        private readonly EventsInfoDbContext _db;

        public Barcelona_vs_Atletico_MadridModel(EventsInfoDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public EventList TheeventList { get; set; }

        public void OnGet()
        {
            TheeventList = _db.EventsTable.FirstOrDefault(e => e.Id == 4);
        }

        public async Task<IActionResult> OnPost()
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
                    await _db.SaveChangesAsync();
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

        [HttpPost]
        public IActionResult OnPostAddToCart(int eventId)
        {
            // Get the current user's email
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            // Get the user details from the database
            var user = _db.CutomersDetails.FirstOrDefault(u => u.Email == userEmail);

            if (user == null)
            {
                // User not found, handle error
                return NotFound();
            }

            // Get the event details from the database using eventId
            var eventToAdd = _db.EventsTable.FirstOrDefault(e => e.Id == eventId);

            if (eventToAdd == null)
            {
                // Event not found, handle error
                return NotFound();
            }

            // Add the event to the cart (attendance table)
            var attendanceItem = new AttendaceList
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                EventTicket = eventToAdd.EventName,
                // Add other properties as needed
            };

            _db.AttendaceTable.Add(attendanceItem);
            _db.SaveChanges();

            // Redirect to the cart page after adding the event to the cart
            return RedirectToPage("/Cart");
        }
    }
}
