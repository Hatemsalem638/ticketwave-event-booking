using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages.Admin
{
    public class UsersListModel : PageModel
    {

        public EventsInfoDbContext _db { get; set; }

        public UsersListModel(EventsInfoDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public SignUpDetails TheSignUpDetails { get; set; }

        public List <SignUpDetails> SignUpDetailsList { get; set; }
        public void OnGet()
        {
            SignUpDetailsList = _db.CutomersDetails.ToList();
        }
    }
}

