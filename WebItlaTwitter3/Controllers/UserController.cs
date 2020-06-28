using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebItlaTwitter3.ViewModels;

namespace WebItlaTwitter3.Controllers
{
    public class UserController : Controller
    {
        private readonly Chris_ItlaTwitterContext _context;

        public UserController(Chris_ItlaTwitterContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            var user = HttpContext.Session.GetString("UserName");

            if (!string.IsNullOrEmpty(user))
            {
                return RedirectToAction("Index", "Usuario");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            var userSession = HttpContext.Session.GetString("UserName");

            if (!string.IsNullOrEmpty(userSession))
            {
                return RedirectToAction("Index", "Usuario");
            }

            if (ModelState.IsValid)
            {
                var passwordEncryted = PasswordEncryption(vm.Password);

                var user = await _context.Usuario.FirstOrDefaultAsync(c => 
                c.NUsuario == vm.NUsuario && c.Password == passwordEncryted);

                if (user != null)
                {
                    HttpContext.Session.SetString("UserName", vm.NUsuario);
                    return RedirectToAction("index", "Usuario");
                }
                else
                {
                    ModelState.AddModelError("UserOrPasswordInvalid", "El usuario o la contraseña es invalido");
                }
            }

                return View(vm);
        }

        public IActionResult Register()
        {
            var userSession = HttpContext.Session.GetString("UserName");

            if (!string.IsNullOrEmpty(userSession))
            {
                return RedirectToAction("Index", "Usuario");
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            var userSession = HttpContext.Session.GetString("UserName");

            if (!string.IsNullOrEmpty(userSession))
            {
                return RedirectToAction("Index", "Usuario");
            }

            if (ModelState.IsValid)
            {
                var usuarioEntity = new Usuario
                {
                    Nombre = vm.Nombre,
                    NUsuario = vm.NUsuario,
                    Correo = vm.Correo,
                    Password = PasswordEncryption(vm.Password)
                };

                var user = await _context.Usuario.FirstOrDefaultAsync(c => c.NUsuario == vm.NUsuario);

                if(user != null)
                {
                    ModelState.AddModelError("UserExits", "Este usuario ya se encuentra registrado");
                    return View(vm);
                }

                _context.Add(usuarioEntity);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login");
            }

            return View(vm);
        }

        private string PasswordEncryption(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();

                foreach (Byte v in bytes)
                {
                    builder.Append(v.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
