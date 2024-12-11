using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers;

public class TeacherController : Controller
{
    private static List <Teacher> teachers = new()
    {
        new() { AdmissionDate = new DateTime(2024,8,1), Age = 35, Firstname = "Mounir", Lastname = "Bendhaman", Major = Major.IT},
    };
    private readonly ILogger<TeacherController> _logger;

    public TeacherController(ILogger<TeacherController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index() 
    {   
        return View(teachers);
    }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
}