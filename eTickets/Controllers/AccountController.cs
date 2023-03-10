using eTickets.Data;
using eTickets.Data.Static;
using eTickets.Data.ViewModel;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public AccountController(RoleManager<IdentityRole> roleManager , UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager  , AppDbContext appDbContext)
        {
            _context = appDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }

        public IActionResult Index()
        {
            return View();
        }
        public new async Task<IActionResult> User()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }
        [AllowAnonymous]
        //Get/Register
        public IActionResult Register()
        {
            return View(); 

        }
        [HttpPost]
       // [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if(user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerVM);
            }
            var newUser = new ApplicationUser()
            {

                FullName =registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName =registerVM.EmailAddress

            };
            var newUserResponse = await _userManager.CreateAsync(newUser,registerVM.Password);
            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                await _signInManager.SignInAsync(newUser,isPersistent: false);
                return RedirectToAction("Index", "Movies");
                
            }
            

            return View(registerVM);

        }
      //  [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginVM());
        }
       // [AllowAnonymous]
        //Post action
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if(!ModelState.IsValid)return View(loginVM);
            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passWordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passWordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                         return RedirectToAction("Index", "Movies"); 
                        
                        
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(loginVM);
            }
            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginVM);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Movies");
        }
        [HttpGet]
        
        public async Task<IActionResult> AddRoles()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRoles(IdentityRole role)
        {
            var roleExist = await _roleManager.RoleExistsAsync(role.Name);

            if (!roleExist)
            {
                //  IdentityRole identityRole = new IdentityRole(name);
                _roleManager.CreateAsync(new IdentityRole(role.Name)).GetAwaiter().GetResult();
                TempData["Add"] = "Adding Role Succeeded";
                return Redirect("User");
            }
            
             
                
            
            return BadRequest(new { error = "Role is already exisist" });

        }
        //public async Task<IActionResult> RemoveRoles()
        //{
        //    return View();
        //}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteUser(string id )
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)return NotFound();
             _userManager.DeleteAsync(user);
            ViewBag.Message = "Form submitted.";
            return RedirectToAction(nameof(user));

           
        }

        //public async Task<IActionResult> Edit()
        //{
        //    _context.Users.FirstOrDefault(id);
        //    return View();
        //}
        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }


    }
}
