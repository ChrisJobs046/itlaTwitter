using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Database.Models;

namespace WebItlaTwitter3.Controllers
{
    public class AmigoController : Controller
    {
        private readonly Chris_ItlaTwitterContext _context;

        public AmigoController(Chris_ItlaTwitterContext context)
        {
            _context = context;
        }

        // GET: Amigo
        public async Task<IActionResult> Index()
        {
            var chris_ItlaTwitterContext = _context.Amigo.Include(a => a.IdUsuarioNavigation).Include(a => a.NUsuario1Navigation);
            return View(await chris_ItlaTwitterContext.ToListAsync());
        }

        // GET: Amigo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amigo = await _context.Amigo
                .Include(a => a.IdUsuarioNavigation)
                .Include(a => a.NUsuario1Navigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (amigo == null)
            {
                return NotFound();
            }

            return View(amigo);
        }

        // GET: Amigo/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Nombre");
            ViewData["NUsuario1"] = new SelectList(_context.Usuario, "IdUsuario", "Nombre");
            return View();
        }

        // POST: Amigo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,NUsuario1")] Amigo amigo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amigo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Nombre", amigo.IdUsuario);
            ViewData["NUsuario1"] = new SelectList(_context.Usuario, "IdUsuario", "Nombre", amigo.NUsuario1);
            return View(amigo);
        }

        // GET: Amigo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amigo = await _context.Amigo.FindAsync(id);
            if (amigo == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Nombre", amigo.IdUsuario);
            ViewData["NUsuario1"] = new SelectList(_context.Usuario, "IdUsuario", "Nombre", amigo.NUsuario1);
            return View(amigo);
        }

        // POST: Amigo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,NUsuario1")] Amigo amigo)
        {
            if (id != amigo.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amigo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmigoExists(amigo.IdUsuario))
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Nombre", amigo.IdUsuario);
            ViewData["NUsuario1"] = new SelectList(_context.Usuario, "IdUsuario", "Nombre", amigo.NUsuario1);
            return View(amigo);
        }

        // GET: Amigo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amigo = await _context.Amigo
                .Include(a => a.IdUsuarioNavigation)
                .Include(a => a.NUsuario1Navigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (amigo == null)
            {
                return NotFound();
            }

            return View(amigo);
        }

        // POST: Amigo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amigo = await _context.Amigo.FindAsync(id);
            _context.Amigo.Remove(amigo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmigoExists(int id)
        {
            return _context.Amigo.Any(e => e.IdUsuario == id);
        }
    }
}
