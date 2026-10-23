using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace soft20181_starter.Pages.Admin
{
    [Authorize(Policy = "RequireLoggedIn")]
    public class AdminPageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
