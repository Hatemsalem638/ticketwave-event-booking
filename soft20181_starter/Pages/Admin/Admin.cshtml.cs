using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace soft20181_starter.Pages.Admin
{
    [Authorize(Policy = "RequireLoggedIn")] // Apply authorization to require logged-in users
    public class AdminModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
