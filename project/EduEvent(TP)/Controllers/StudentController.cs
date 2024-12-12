using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EduEvent.Data;
using EduEvent.Models;

namespace EduEvent.Controllers;

public class StudentController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<Student> _userManager;

    private static List <Student> students = new()
    {
        // new() { AdmissionDate = new DateTime(2024,8,1), Age = 20, Firstname = "Maxime", Lastname = "Girardet", GPA = 12, Major = Major.IT, Id =1},
        
    };
    public StudentController(ApplicationDbContext context, UserManager<Student> userManager)
    {
        _context = context;
        _userManager = userManager;
        
    }
    


}

