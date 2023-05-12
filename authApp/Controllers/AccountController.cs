using authApp.Data;
using authApp.Models.DtoModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace authApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Account user, string? returnUrl = null)
        {
            // Validating User model is valid or not
            if (ModelState.IsValid)
            {

                if (user.EmailId == "sahilkhatri4537@gmail.com" && user.Password == "Admin123")
                {
                    var identity = new ClaimsIdentity(
                        new[]
                        {
                            new Claim(ClaimTypes.NameIdentifier, "userId"),
                            new Claim(ClaimTypes.Name, "userName"),
                        },
                        authenticationType: "ApplicationCookie"
                        );

                    var AuthenticationOption = new AuthenticationProperties { };
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(identity),
                        AuthenticationOption);
                    return RedirectToAction("Index", "Dashboard");

                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt");
                }
                
            }
            return View(user);
        }
    }
}