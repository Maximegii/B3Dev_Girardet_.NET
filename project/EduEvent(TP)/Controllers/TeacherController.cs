using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EduEvent.Data;
using EduEvent.Models;
using Microsoft.AspNetCore.Identity;

namespace EduEvent.Controllers;

public class TeacherController : Controller
{
    private static List <Teacher> teachers = new()
    {
        // new() { AdmissionDate = new DateTime(2024,8,1), Age = 35, Firstname = "Mounir", Lastname = "Bendhaman", Major = Major.IT},
    };
    

    private readonly UserManager<Teacher> _userManager;

    public TeacherController(UserManager<Teacher> userManager)
    {
        _userManager = userManager;
        
    }

}