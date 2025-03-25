using AgroVA.Domain.Account;
using AgroVA.Domain.Messages;
using AgroVA.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AgroVA.WebUI.Controllers;

public class AccountController : Controller
{
    private readonly IAuthenticate _authenticateService;

    public AccountController(IAuthenticate authenticateService)
    {
        _authenticateService = authenticateService;
    }

    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        return View(
            new LoginViewModel()
            {
                ReturnUrl = returnUrl
            }
        );
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var result = await _authenticateService.Authenticate(model.Email, model.Password);

        if (result)
        {
            if (string.IsNullOrEmpty(model.ReturnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(model.ReturnUrl);
        }
        else
        {
            ModelState.AddModelError(string.Empty, AccountMessages.InvalidLoginAttempt);
            return View(model);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        var result = await _authenticateService.Register(model.Email, model.Password);

        if (result)
            return RedirectToAction("Index", "Home");
        else
            ModelState.AddModelError(string.Empty, AccountMessages.InvalidRegisterAttempt);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _authenticateService.Logout();
        return RedirectToAction("Index", "Home");
    }

}
