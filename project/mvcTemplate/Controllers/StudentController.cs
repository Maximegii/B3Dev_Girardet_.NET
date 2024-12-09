using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers;

public class StudentController : Controller
{
    private static List <Student> students = new()
    {
        new() { AdmissionDate = new DateTime(2024,8,1), Age = 20, Firstname = "Maxime", Lastname = "Girardet", GPA = 12, Major = Major.IT}
    }
    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index() 
    {   
        return View(students);
    }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
}