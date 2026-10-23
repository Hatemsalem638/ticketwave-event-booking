using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace soft20181_starter.Pages
{
    public class CheckoutPageModel : PageModel
    {
        private readonly EventsInfoDbContext _db;

        public CheckoutPageModel(EventsInfoDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public AttendaceList TheAttendaceList { get; set; }

        public List<string> EventNames { get; set; }

        public IActionResult OnGet()
        {
            // Populate the dropdown list with event names from the EventsTable
            EventNames = _db.EventsTable.Select(e => e.EventName).ToList();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Set the current date and time

                // Add the attendance to the database
                _db.AttendaceTable.Add(TheAttendaceList);
                _db.SaveChanges();

                // Redirect to a confirmation page or another page as needed
                return RedirectToPage("/Cart");
            }
            // If model state is invalid, return the page with validation errors
            return Page();
        }
    }
}
