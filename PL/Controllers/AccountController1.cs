using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PL.Helper;
using PL.Models;

namespace PL.Controllers
{
    public class AccountController1 : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController1(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult SignUp()
        {
            return View(new RegisterVM());
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterVM registerVM)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    Email=registerVM.Email,
                    UserName = registerVM.Email.Split('@')[0],
                    IsAgree=registerVM.IsAgree
                };
                var result = await _userManager.CreateAsync(user, registerVM.PassWord);
                if(result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(registerVM);
        }
        public IActionResult Login(string? ReturnURL)
        {
            return View(new LoginVM());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM )
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginVM.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Email does not exist");
                }
                var isCorrectPassword = await _userManager.CheckPasswordAsync(user,loginVM.PassWord);
                if (isCorrectPassword)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.PassWord, loginVM.RememberMe, false);
                    if(result.Succeeded)
                        return RedirectToAction("Index", "Home");

                
                }
                    
            }

            return View(loginVM);
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        
        
        #region ForgetPassword
        public IActionResult ForgetPassword()
        {
            return View(new ForgetPasswordVM());
        }
        [HttpPost]
        public async Task< IActionResult> ForgetPassword(ForgetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if(user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var resetPasswordLink = Url.Action("ResetPassword", "Account", 
                                                        new { Email = model.Email, Token = token }, Request.Scheme);
                    var email = new Email
                    {
                        Title = "Reset Password",
                        Body = resetPasswordLink,
                        To = model.Email
                    };
                    EmailSetting.SendEmail(email);
                    return RedirectToAction("CompleteForgetPassword");
                }
                ModelState.AddModelError("", "Invalid Email");
                

            }
            return View(model);
        }
        public IActionResult CompleteForgetPassword()
        {
            return View();
        }
        #endregion

        #region ResetPassword
        public IActionResult ResetPassword(string mail, string token)
        {
            return View(new ResetPasswordVM() );
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.PassWord);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Login));
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);

                    }
                }

            }
            return View(model);
        }

        #endregion

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
