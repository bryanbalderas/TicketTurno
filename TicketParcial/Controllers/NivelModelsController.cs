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
    public class NivelModelsController : Controller
    {
        private readonly TicketTurnoContext _context;

        public NivelModelsController(TicketTurnoContext context)
        {
            _context = context;
        }

        // GET: NivelModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.NivelesList.ToListAsync());
        }

        // GET: NivelModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivelModel = await _context.NivelesList
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nivelModel == null)
            {
                return NotFound();
            }

            return View(nivelModel);
        }

        // GET: NivelModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NivelModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,descripcion")] NivelModel nivelModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nivelModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nivelModel);
        }

        // GET: NivelModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivelModel = await _context.NivelesList.FindAsync(id);
            if (nivelModel == null)
            {
                return NotFound();
            }
            return View(nivelModel);
        }

        // POST: NivelModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,descripcion")] NivelModel nivelModel)
        {
            if (id != nivelModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nivelModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NivelModelExists(nivelModel.ID))
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
            return View(nivelModel);
        }

        // GET: NivelModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivelModel = await _context.NivelesList
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nivelModel == null)
            {
                return NotFound();
            }

            return View(nivelModel);
        }

        // POST: NivelModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nivelModel = await _context.NivelesList.FindAsync(id);
            _context.NivelesList.Remove(nivelModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NivelModelExists(int id)
        {
            return _context.NivelesList.Any(e => e.ID == id);
        }
    }
}
