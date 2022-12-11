using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Monix.Extensions;
using Monix.ViewModels;

namespace Monix.Controllers;

public class UserController : Controller
{
    public readonly UserManager<IdentityUser> UserManager;

    public UserController(UserManager<IdentityUser> userManager)
    {
        UserManager = userManager;
    }
    
    // GET
    public async Task<IActionResult> Register(string id)
    {
        var user = await UserManager.FindByIdAsync(id);
        if (user == null)
        {
            this.ShowMessage("Usuario não encontrado.", true);
            return RedirectToAction("Index", "Home");
        }

        var userViewModel = new UserRegisterViewModel
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,

        };
        return View(user);
    }
}