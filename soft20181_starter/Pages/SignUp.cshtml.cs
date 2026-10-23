using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
    public class SignUpModel : PageModel
    {

        public EventsInfoDbContext _db { get; set; }

        public SignUpModel(EventsInfoDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public SignUpDetails TheSignUpDetails { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _db.CutomersDetails.Add(TheSignUpDetails);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
