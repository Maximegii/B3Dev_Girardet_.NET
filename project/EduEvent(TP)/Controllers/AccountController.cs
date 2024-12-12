using EduEvent.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        if (!ModelState.IsValid) return View();

        var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError(string.Empty, "Échec de la connexion. Vérifiez vos identifiants.");
        return View();
    }

    [HttpGet]
    public IActionResult TeacherRegister()
    {
        return View();
    }

   [HttpPost]
    public async Task<IActionResult> TeacherRegister(AccountViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var teacher = new User
        {
            UserName = model.Email,
            Email = model.Email,
            Firstname = model.Firstname,
            Lastname = model.Lastname
        };

        var result = await _userManager.CreateAsync(teacher, model.Password);
        if (result.Succeeded)
        {
            if (!await _roleManager.RoleExistsAsync("Prof"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Prof"));
            }
            await _userManager.AddToRoleAsync(teacher, "Prof");

            await _signInManager.SignInAsync(teacher, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult StudentRegister()
    {
        return View();
    }

    public async Task<IActionResult> StudentRegister(AccountViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var student = new User
        {
            UserName = model.Email,
            Email = model.Email,
            Firstname = model.Firstname,
            Lastname = model.Lastname
        };

        var result = await _userManager.CreateAsync(student, model.Password);
        if (result.Succeeded)
        {
            if (!await _roleManager.RoleExistsAsync("Élève"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Élève"));
            }
            await _userManager.AddToRoleAsync(student, "Élève");

            await _signInManager.SignInAsync(student, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(model);
    }

    [HttpGet]
public async Task<IActionResult> Logout()
{
    await _signInManager.SignOutAsync();
    return RedirectToAction("Login");
}


    
}
