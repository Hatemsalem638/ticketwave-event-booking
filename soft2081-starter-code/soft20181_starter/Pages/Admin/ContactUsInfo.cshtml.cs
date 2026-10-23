using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages.Admin
{
    public class ContactUsInfoModel : PageModel
    {
        public EventsInfoDbContext _db { get; set; }

        public ContactUsInfoModel(EventsInfoDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Messages TheMessages { get; set; }

        public List<Messages> MessagesList { get; set; }
        public void OnGet()
        {
            MessagesList = _db.CustomersMessages.ToList();
        }
        
    }
}
