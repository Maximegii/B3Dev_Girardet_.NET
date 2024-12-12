using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EduEvent.Data;
using EduEvent.Models;

namespace EduEvent.Controllers;

[Authorize] 
public class EventController : Controller
{
    private readonly ApplicationDbContext _context;

    public EventController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index() 
    {   
        var events = _context.Events.ToList();
        return View(events);
    }
    
    [Authorize(Roles = "Prof")]
    public IActionResult Create()
    {
        return View();
    }
    [Authorize(Roles = "Prof")]
    [HttpPost]
    public IActionResult Create(Event eventModel)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        
        _context.Events.Add(eventModel);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    [Authorize(Roles = "Prof")]
    public IActionResult Edit(int id)
    {
        var eventModel = _context.Events.Find(id);
        if (eventModel == null)
        {
            return NotFound();
        }
        return View(eventModel);
    }
    [Authorize(Roles = "Prof")]
    [HttpPost]
    public IActionResult Edit(Event updatedEvent)
    {
        if (!ModelState.IsValid)
        {
            return View(updatedEvent);
        }

        var existingEvent = _context.Events.Find(updatedEvent.Id);
        if (existingEvent == null)
        {
            return NotFound();
        }

        existingEvent.Title = updatedEvent.Title;
        existingEvent.Description = updatedEvent.Description;
        existingEvent.EventDate = updatedEvent.EventDate;
        existingEvent.MaxParticipants = updatedEvent.MaxParticipants;
        existingEvent.Location = updatedEvent.Location;

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
    [Authorize(Roles = "Prof")]
    public IActionResult Delete(int id)
    {
        var eventModel = _context.Events.Find(id);
        if (eventModel == null)
        {
            return NotFound();
        }
        return View(eventModel);
    }
    [Authorize(Roles = "Prof")]
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var eventModel = _context.Events.Find(id);
        if (eventModel != null)
        {
            _context.Events.Remove(eventModel);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Detail(int id)
    {
        var eventModel = _context.Events.Find(id);
        if (eventModel == null)
        {
            return NotFound();
        }
        return View(eventModel);
    }
}
