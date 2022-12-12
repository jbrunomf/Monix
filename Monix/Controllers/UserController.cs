using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Monix.Extensions;
using Monix.ViewModels;

namespace Monix.Controllers;

public class UserController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public UserController(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // GET
    public async Task<IActionResult> Register(string? id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                this.ShowMessage("Usuário não encontrado.", true);
                return RedirectToAction("Index", "Home");
            }

            var userViewModel = new UserRegisterViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
            return View(userViewModel);
        }

        return View(new UserRegisterViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserRegisterViewModel viewModel)
    {
        var user = await _userManager.FindByEmailAsync(viewModel.Email);
        if (user != null)
        {
            ModelState.AddModelError("Email", "Este endereço de email já está em uso.");
            return View(viewModel);
        }

        user = new IdentityUser
        {
            UserName = viewModel.UserName,
            Email = viewModel.Email,
            PhoneNumber = viewModel.PhoneNumber,
        };
        var result = await _userManager.CreateAsync(user, viewModel.Password);

        if (result.Succeeded)
        {
            this.ShowMessage("Usuário cadastrado com sucesso.");
        }

        return RedirectToAction("Index", controllerName: "Home");
    }

    private bool UserExists(string id)
    {
        return _userManager.Users.AsNoTracking().Any(u => u.Id == id);
    }

    [HttpGet]
    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromForm] UserLoginViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password,
                viewModel.RememberUsername, false);

            if (result.Succeeded)
            {
                viewModel.ReturnUrl = viewModel.ReturnUrl ?? "~/";
                return LocalRedirect(viewModel.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty,
                    "Tentativa de login inválida. Verifique os dados de acesso e tente novamente.");
            }

            return View(viewModel);
        }

        return View(viewModel);
    }
}