using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketParcial.Infrastructure;
using TicketParcial.Models;

namespace TicketParcial.Controllers
{
    public class AsuntoController : Controller
    {
        private readonly TicketTurnoContext _context;

        public AsuntoController(TicketTurnoContext context)
        {
            _context = context;
        }

        // GET: Asunto
        public async Task<IActionResult> Index()
        {
            return View(await _context.AsuntosList.ToListAsync());
        }

        // GET: Asunto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asuntoModel = await _context.AsuntosList
                .FirstOrDefaultAsync(m => m.ID == id);
            if (asuntoModel == null)
            {
                return NotFound();
            }

            return View(asuntoModel);
        }

        // GET: Asunto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Asunto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,descripcion")] AsuntoModel asuntoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asuntoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asuntoModel);
        }

        // GET: Asunto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asuntoModel = await _context.AsuntosList.FindAsync(id);
            if (asuntoModel == null)
            {
                return NotFound();
            }
            return View(asuntoModel);
        }

        // POST: Asunto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,descripcion")] AsuntoModel asuntoModel)
        {
            if (id != asuntoModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asuntoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsuntoModelExists(asuntoModel.ID))
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
            return View(asuntoModel);
        }

        // GET: Asunto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asuntoModel = await _context.AsuntosList
                .FirstOrDefaultAsync(m => m.ID == id);
            if (asuntoModel == null)
            {
                return NotFound();
            }

            return View(asuntoModel);
        }

        // POST: Asunto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asuntoModel = await _context.AsuntosList.FindAsync(id);
            _context.AsuntosList.Remove(asuntoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsuntoModelExists(int id)
        {
            return _context.AsuntosList.Any(e => e.ID == id);
        }
    }
}
