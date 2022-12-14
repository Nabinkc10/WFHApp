using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WFHMS.Data.Entities;
using WFHMS.Models.ViewModel;

namespace NewIdentity.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in Use");
            }


        }


            [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            { 
                var user = new ApplicationUser{ UserName = model.Email, Email = model.Email,City=model.City };
               var result = await userManager.CreateAsync(user,model.Password);
            
                if(result.Succeeded)
                {
                    if(signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "Administration");
                    }

                   await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "home");  
        }
        [HttpGet]
        [AllowAnonymous]

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Login(LoginViewModel model , string? returnUrl)
        
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email,model.Password,model.RememberMe,false);

                if (result.Succeeded)               //may be issue in this for login
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "home");

                    }
                }
                
                    ModelState.AddModelError(String.Empty, "Invalid Login Attempts");
               
            }

            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }








    }
}
