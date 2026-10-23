using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages.Admin
{
    public class EditUsersModel : PageModel
    {
        public EventsInfoDbContext _db { get; set; }

        public EditUsersModel(EventsInfoDbContext db)
        {
            _db = db;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }


        [BindProperty]
        public SignUpDetails TheSignUpDetails { get; set; }
        public void OnGet()
        {
            TheSignUpDetails = _db.CutomersDetails.Find(Id);
        }


        public IActionResult OnGetDelete() 
        {
            TheSignUpDetails = _db.CutomersDetails.Find(Id);
            _db.CutomersDetails.Remove(TheSignUpDetails);
            _db.SaveChanges();
            return RedirectToPage("Admin/UsersList");
        }
        public IActionResult OnPost()
        {
            _db.CutomersDetails.Update(TheSignUpDetails);
            _db.SaveChanges();
            return RedirectToPage("Admin/index");
        }
    }
}
