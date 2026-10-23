using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;
using System.Collections.Generic;
using System.Linq;

public class TicketModel : PageModel
{
    private readonly EventsInfoDbContext _db;
    private static Random random = new Random();

    public TicketModel(EventsInfoDbContext db)
    {
        _db = db;
    }

    public List<AttendaceList> CartItems { get; set; }
    public List<EventList> Events { get; set; }

    public void OnGet()
    {
        // Retrieve items from the cart (AttendanceTable)
        CartItems = _db.AttendaceTable.ToList();
        Events = _db.EventsTable.ToList();
    }

    public string GenerateTicketNumber(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var ticketNumber = new StringBuilder(length);
        for (int i = 0; i < length; i++)
        {
            ticketNumber.Append(chars[random.Next(chars.Length)]);
        }
        return ticketNumber.ToString();
    }
}
