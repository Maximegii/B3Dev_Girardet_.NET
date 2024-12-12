
using EduEvent.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EduEvent.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<Student> _signInManager;
    private readonly UserManager<Student> _userManager;

    
    public AccountController(SignInManager<Student> signInManager, UserManager<Student> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

//     [HttpPost]
//     public async Task<IActionResult> Login(Student)
//     {
//         try
//         {
//             if (!ModelState.IsValid)
//                 return View(Index);

//             var result = await _signInManager
//                 .PasswordSignInAsync(Model.Username!, model.Password!, model.RememberMe, false);

//             if (!result.Succeeded)
//             {
//                 ModelState.AddModelError("", "Erreur lors de la connexion");
//                 TempData["ErrorMessage"] = "Erreur lors de la connexion";
//                 return View(model);
//             }
            
//             TempData["SuccessMessage"] = "Bienvenue sur votre tableau de bord !";
//             return RedirectToAction("Index", "Dashboard");
//         } catch (Exception e)
//         {
//             _logger.LogError(e, "Error while logging in");
//             return RedirectToAction("Index", "Error");
//         }
//     }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(AccountViewModel model)
    {

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = new Student
        {
            UserName = model.Firstname + model.Lastname,
            Email = model.Email,
            Firstname = model.Firstname,
            Lastname = model.Lastname,
            // ConfirmedPassword = model.ConfirmedPassword,
            
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(model);
    }
    
//     // [HttpGet]
//     // public async Task<IActionResult> Logout()
//     // {
//     //     await _signInManager.SignOutAsync();
//     //     return RedirectToAction("Login");
//     // }
    
//     // // GET
//     // public IActionResult Index()
//     // {
//     //     return RedirectToAction("Login");
//     // }

//     // [HttpGet]
//     // [Authorize]
//     // public async Task<IActionResult> Edit()
//     // {
//     //     var user = await _userManager.GetUserAsync(User);
        
//     //     if (user == null)
//     //         return NotFound("Utilisateur introuvable ou non connecté");

//     //     var model = new AccountViewModel
//     //     {
//     //         Username = user.UserName,
//     //         Email = user.Email,
//     //         FirstName = user.FirstName,
//     //         LastName = user.LastName,
//     //         Password = user.PasswordHash,
//     //         Address = user.Address,
//     //         Faculty = user.Faculty,
//     //         Specialty = user.Specialty
//     //     };
        
//     //     return View(model);
//     // }
    
//     // [HttpPost]
//     // [Authorize]
//     // public async Task<IActionResult> Edit(AccountViewModel model)
//     // {
//     //     try
//     //     {
//     //         if (!ModelState.IsValid)
//     //         {
//     //             TempData["ErrorMessage"] = "Erreur lors de la modification";
//     //             return View(model);
//     //         }

//     //         var user = await _userManager.GetUserAsync(User);
            
//     //         if (user == null)
//     //             return NotFound("Utilisateur introuvable ou non connecté");

//     //         user.UserName = model.Username;
//     //         user.NormalizedUserName = model.Username!.ToUpper();
//     //         user.Email = model.Email;
//     //         user.NormalizedEmail = model.Email!.ToUpper();
//     //         user.FirstName = model.FirstName!;
//     //         user.LastName = model.LastName!;
//     //         user.Address = model.Address!;
//     //         user.Faculty = model.Faculty!;
//     //         user.Specialty = model.Specialty!;

//     //         var passwordHasher = new PasswordHasher<Student>();
//     //         user.PasswordHash = passwordHasher.HashPassword(user, model.Password!);

//     //         var result = await _userManager.UpdateAsync(user);

//     //         if (result.Succeeded) return RedirectToAction("Index", "Dashboard");
            
//     //         foreach (var error in result.Errors)
//     //         {
//     //             ModelState.AddModelError(string.Empty, error.Description);
//     //             TempData["ErrorMessage"] = "Erreur lors de la modification";
//     //         }
            
//     //         TempData["SuccessMessage"] = "Votre profil a été mis à jour avec succès";
//     //         return View(model);
//     //     } 
//     //     catch (Exception e)
//     //     {
//     //         _logger.LogError(e, "Error while editing user");
//     //         return RedirectToAction("Index", "Error");
//     //     }
//     // }
}