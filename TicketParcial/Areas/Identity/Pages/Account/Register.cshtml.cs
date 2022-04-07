using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using TicketParcial.Areas.Identity.Data;

namespace TicketParcial.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<TicketParcialUser> _signInManager;
        private readonly UserManager<TicketParcialUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        private readonly ReCaptcha _captcha;

        public RegisterModel(
            UserManager<TicketParcialUser> userManager,
            SignInManager<TicketParcialUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ReCaptcha captcha)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _captcha = captcha;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "El campo email es requerido.")]
            [EmailAddress(ErrorMessage = "El campo email no cuenta con un email válido.")]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Email", Prompt = "Ingresa tu email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "El campo nombre es requerido.")]
            [DataType(DataType.Text)]
            [Display(Name = "Nombre", Prompt = "Ingresa tu nombre")]
            public string Nombre { get; set; }

            [Required(ErrorMessage = "El campo apellido es requerido.")]
            [DataType(DataType.Text)]
            [Display(Name = "Apellido", Prompt = "Ingresa tu apellido")]
            public string Apellido { get; set; }

            [Required(ErrorMessage = "El campo contraseña es requerido.")]
            [StringLength(100, ErrorMessage = "La contraseña debe contener al menos {2} caracteres y máximo {1}.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña", Prompt = "Ingresa tu contraseña")]
            public string Password { get; set; }

            [Required(ErrorMessage = "El campo confirmar contraseña es requerido.")]
            [DataType(DataType.Password)]
            [Display(Name = "Confirmar contraseña", Prompt = "Confirma tu contraseña")]
            [Compare("Password", ErrorMessage = "Las contraseñas deben coincidir.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                if (!Request.Form.ContainsKey("g-recaptcha-response")) return Page();
                var captcha = Request.Form["g-recaptcha-response"].ToString();
                if (!await _captcha.IsValid(captcha)) return Page();
                var user = new TicketParcialUser { UserName = Input.Email, Email = Input.Email, Nombre=Input.Nombre, Apellido= Input.Apellido };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}
