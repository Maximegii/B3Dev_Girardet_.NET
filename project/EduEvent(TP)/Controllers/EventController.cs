using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EduEvent.Data;
using EduEvent.Models;

namespace EduEvent.Controllers;

public class EventController : Controller
{
    private readonly ApplicationDbContext _context;

    public EventController(ApplicationDbContext context)
    {
        _context = context;
        
        
    }
    

    public IActionResult Index() 
    {   
        var Event = _context.Events.ToList();
        return View(Event);
    }
    public IActionResult Create()
    {
        return View();
    }
}

// [HttpPost]
// public IActionResult Add(Student student)
//     {
//         // Declencher le mecanisme de validation
//         if (!ModelState.IsValid)
//         {
//             return View();
//         }
//         // Ajouter le teacher
//         _context.Students.Add(student);

//         // Sauvegarder les changements
//         _context.SaveChanges();
//         return RedirectToAction("Index");
//     }
// public IActionResult Edit(int id)
// {
//     var student = _context.Students.Find(id);
//     if (student == null)
//     {
//         return NotFound();
//     }
    
//     return View(student);
// }
// [HttpPost]
// public IActionResult Edit(Student updatedStudent)
// {
//     if (!ModelState.IsValid)
//     {
//         return View(updatedStudent);
//     }

//     var student = _context.Students.Find(updatedStudent.Id);
//     if (student == null)
//     {
//         return NotFound();
//     }

//     _context.Students.Update(student);
//     _context.SaveChanges();

//     return RedirectToAction(nameof(Index));
// }
// public IActionResult Delete(int id)
// {
//     var student = _context.Students.Find(id);
//     if (student == null)
//     {
//         return NotFound();
//     }
//     return View(student);
// }

// [HttpPost, ActionName("Delete")]
// public IActionResult DeleteConfirmed(int id)
// {
//     var student = _context.Students.Find(id);
//     if (student != null)
//     {
//         _context.Students.Remove(student);
//         _context.SaveChanges();
//     }
//     return RedirectToAction(nameof(Index));
    
// }
//  public IActionResult ShowDetails(int id)
//     {
//         var student = _context.Students.Find(id);
       
//         return View(student);
//     }


    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
// }