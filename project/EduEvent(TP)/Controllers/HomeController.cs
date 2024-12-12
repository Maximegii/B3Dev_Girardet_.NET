using Microsoft.AspNetCore.Mvc;
using EduEvent.Data;
using EduEvent.Models;
using System;
using System.Linq;

namespace EduEvent.Controllers;

public class HomeController : Controller
{
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
    public IActionResult Index(string searchTitle, DateTime? searchDate)
    {
        var startOfWeek = DateTime.Now.Date;
        var endOfWeek = startOfWeek.AddDays(7);

        var events = _context.Events
            .Where(e => e.EventDate >= startOfWeek && e.EventDate <= endOfWeek);

        if (!string.IsNullOrEmpty(searchTitle))
        {
             events = events.Where(e => e.Title.ToLower().Contains(searchTitle.ToLower()));
        }

        if (searchDate.HasValue)
        {
            events = events.Where(e => e.EventDate.Date == searchDate.Value.Date);
        }

        return View(events.ToList());
    }

}

