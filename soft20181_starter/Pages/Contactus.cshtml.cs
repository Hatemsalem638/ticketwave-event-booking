using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
    public class ContactusModel : PageModel
    {
        private readonly EventsInfoDbContext _db;

        public ContactusModel(EventsInfoDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Messages TheMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.CustomersMessages.Add(TheMessage);
                    _db.SaveChanges();
                    return RedirectToPage("/Index"); // Redirect to another page after successful save
                }
                else
                {
                    // Model state is not valid, return the page with validation errors
                    return Page();
                }
            }
            catch (Exception ex)
            {
                // Log the exception or display an error message
                ModelState.AddModelError(string.Empty, "An error occurred while saving the data.");
                return Page();
            }
        }
    }
}
