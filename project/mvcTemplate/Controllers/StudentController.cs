using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers;

public class StudentController : Controller
{
    private static List <Student> students = new()
    {
        new() { AdmissionDate = new DateTime(2024,8,1), Age = 20, Firstname = "Maxime", Lastname = "Girardet", GPA = 12, Major = Major.IT, Id =1},
        new() { AdmissionDate = new DateTime(2024,8,1), Age = 19, Firstname = "Yohann", Lastname = "Mathieux", GPA = 12, Major = Major.IT, Id=2},
        new() { AdmissionDate = new DateTime(2024,8,1), Age = 20, Firstname = "Arthur", Lastname = "Nova", GPA = 12, Major = Major.IT, Id=3},
        new() { AdmissionDate = new DateTime(2024,8,1), Age = 21, Firstname = "Lester", Lastname = "Tageule", GPA = 12, Major = Major.IT, Id=4},
    };
    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index() 
    {   
        return View(students);
    }
    public IActionResult Add()
{
    return View();
}

[HttpPost]
public IActionResult Add(Student student)
{
    if (ModelState.IsValid)
    {
        student.Id = students.Max(e => e.Id) + 1;
        students.Add(student);
        return RedirectToAction(nameof(Index));
    }
    return View(student);
}
public IActionResult Edit(int id)
{
   var student = students.FirstOrDefault(e => e.Id == id);
    if (student == null)
    {
        return NotFound();
    }
    
    return View(student);
}
[HttpPost]
public IActionResult Edit(Student updatedStudent)
{
    if (!ModelState.IsValid)
    {
        return View(updatedStudent);
    }

    var student = students.FirstOrDefault(e => e.Id == updatedStudent.Id);
    if (student == null)
    {
        return NotFound();
    }

    
    student.Firstname = updatedStudent.Firstname;
    student.Lastname = updatedStudent.Lastname;
    student.Age = updatedStudent.Age;
    student.AdmissionDate = updatedStudent.AdmissionDate;
    student.GPA = updatedStudent.GPA;
    student.Major = updatedStudent.Major;

    return RedirectToAction(nameof(Index));
}
public IActionResult Delete(int id)
{
    var student = students.FirstOrDefault(e => e.Id == id);
    if (student == null)
    {
        return NotFound();
    }
    return View(student);
}

[HttpPost, ActionName("Delete")]
public IActionResult DeleteConfirmed(int id)
{
    var student = students.FirstOrDefault(e => e.Id == id);
    if (student != null)
    {
        students.Remove(student);
    }
    return RedirectToAction(nameof(Index));
}
public IActionResult ShowDetails(int id)
{
    var student = students.FirstOrDefault(e => e.Id == id);
    if (student == null)
    {
        return NotFound();
    }
    return View(student);
}

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
}