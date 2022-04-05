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
    public class MunicipioController : Controller
    {
        private readonly TicketTurnoContext _context;

        public MunicipioController(TicketTurnoContext context)
        {
            _context = context;
        }

        // GET: Municipio
        public async Task<IActionResult> Index()
        {
            return View(await _context.MunicipiosList.ToListAsync());
        }

        // GET: Municipio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipioModel = await _context.MunicipiosList
                .FirstOrDefaultAsync(m => m.ID == id);
            if (municipioModel == null)
            {
                return NotFound();
            }

            return View(municipioModel);
        }

        // GET: Municipio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Municipio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,descripcion")] MunicipioModel municipioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(municipioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(municipioModel);
        }

        // GET: Municipio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipioModel = await _context.MunicipiosList.FindAsync(id);
            if (municipioModel == null)
            {
                return NotFound();
            }
            return View(municipioModel);
        }

        // POST: Municipio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,descripcion")] MunicipioModel municipioModel)
        {
            if (id != municipioModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(municipioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MunicipioModelExists(municipioModel.ID))
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
            return View(municipioModel);
        }

        // GET: Municipio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipioModel = await _context.MunicipiosList
                .FirstOrDefaultAsync(m => m.ID == id);
            if (municipioModel == null)
            {
                return NotFound();
            }

            return View(municipioModel);
        }

        // POST: Municipio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var municipioModel = await _context.MunicipiosList.FindAsync(id);
            _context.MunicipiosList.Remove(municipioModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MunicipioModelExists(int id)
        {
            return _context.MunicipiosList.Any(e => e.ID == id);
        }
    }
}
