using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using soft20181_starter.Models;
using System.Collections.Generic;
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

        public List<AttendaceList> CartItems { get; set; }

        public void OnGet()
        {
            // Retrieve items from the cart (AttendanceTable)
            CartItems = _db.AttendaceTable.ToList();
        }
    }
}
