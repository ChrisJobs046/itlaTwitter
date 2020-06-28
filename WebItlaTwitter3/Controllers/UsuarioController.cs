using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Database.Models;
using WebItlaTwitter3.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;

namespace WebItlaTwitter3.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Chris_ItlaTwitterContext _context;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IMapper _mapper;

        public UsuarioController(Chris_ItlaTwitterContext context, IHostingEnvironment hostingEnvironment, IMapper mapper)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
            this._mapper = mapper;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            var user = HttpContext.Session.GetString("UserName");

            if (string.IsNullOrEmpty(user))
            {
                return RedirectToAction("AccesoDenegado","Home");
            }

            var listEntity = await _context.Usuario.ToListAsync();

            List<UsuarioViewModel> vms = new List<UsuarioViewModel>();

            listEntity.ForEach(item =>
            {
                var vm = _mapper.Map<UsuarioViewModel>(item);

                vms.Add(vm);
                
            });
            return View(vms);
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            var vm = new UsuarioViewModel
            {
                IdUsuario = usuario.IdUsuario,
                NUsuario = usuario.NUsuario
            };

            return View(vm);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioViewModel vm)
        {
            var user = HttpContext.Session.GetString("UserName");

            if (string.IsNullOrEmpty(user))
            {
                return RedirectToAction("AccesoDenegado", "Home");
            }

            if (ModelState.IsValid)
            {
                var entity = new Usuario
                {
                    IdUsuario = vm.IdUsuario,
                    NUsuario = vm.NUsuario
                };

                _context.Add(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var user = HttpContext.Session.GetString("UserName");

            if (string.IsNullOrEmpty(user))
            {
                return RedirectToAction("AccesoDenegado", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            var vm = new UsuarioViewModel
            {
                IdUsuario = usuario.IdUsuario,
                NUsuario = usuario.NUsuario
            };

            return View(vm);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UsuarioViewModel vm)
        {
            var user = HttpContext.Session.GetString("UserName");

            if (string.IsNullOrEmpty(user))
            {
                return RedirectToAction("AccesoDenegado", "Home");
            }

            if (id != vm.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var entity = new Usuario
                    {
                        IdUsuario = vm.IdUsuario,
                        NUsuario = vm.NUsuario
                    };

                    _context.Update(entity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(vm.IdUsuario))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var user = HttpContext.Session.GetString("UserName");

            if (string.IsNullOrEmpty(user))
            {
                return RedirectToAction("AccesoDenegado", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            var vm = new Usuario
            {
                IdUsuario = usuario.IdUsuario,
                NUsuario = usuario.NUsuario
            };

            return View(vm);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = HttpContext.Session.GetString("UserName");

            if (string.IsNullOrEmpty(user))
            {
                return RedirectToAction("AccesoDenegado", "Home");
            }

            var usuario = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.IdUsuario == id);
        }
    }
}
