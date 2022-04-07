using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketParcial.Infrastructure;
using TicketParcial.Models;

namespace TicketParcial.Controllers
{
    public class TicketTurnoController : Controller
    {
        private readonly TicketTurnoContext _context;

        public TicketTurnoController(TicketTurnoContext context)
        {
            _context = context;
        }



        // GET: TicketTurnoModels
        public async Task<IActionResult> Index(string searchString, int ticket)
        {
            var tickets = from m in _context.TicketTurnoList
                         select m;

            if (!String.IsNullOrEmpty(searchString) && ticket!=0)
            {
                tickets = tickets.Where(s => s.curp!.Equals(searchString));

                tickets = tickets.Where(s => s.ID!.Equals(ticket));
            }
            else
            {
                List<TicketTurnoModel> lista;
                lista = new List<TicketTurnoModel>();
                return View(lista);
            }

            return View(await tickets.ToListAsync());

            //return View(await _context.TicketTurnoList.ToListAsync());
        }

        // GET: TicketTurnoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketTurnoModel = await _context.TicketTurnoList
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ticketTurnoModel == null)
            {
                return NotFound();
            }

            return View(ticketTurnoModel);
        }

        // GET: TicketTurnoModels/Create
        public IActionResult Create()
        {
            ViewData["municipioID"] = new SelectList(_context.MunicipiosList, "ID", "descripcion");
            ViewData["asuntoID"] = new SelectList(_context.AsuntosList, "ID", "descripcion");
            ViewData["nivelID"] = new SelectList(_context.NivelesList, "ID", "descripcion");
            return View();
        }

        // POST: TicketTurnoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nombreRealiza,curp,nombre,paterno,materno,telefono,celular,correo,asuntoID,municipioID,nivelID")] TicketTurnoModel ticketTurnoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketTurnoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["municipioID"] = new SelectList(_context.MunicipiosList, "ID", "descripcion",ticketTurnoModel.municipio);
            ViewData["asuntoID"] = new SelectList(_context.AsuntosList, "ID", "descripcion",ticketTurnoModel.asunto);
            ViewData["nivelID"] = new SelectList(_context.NivelesList, "ID", "descripcion",ticketTurnoModel.nivel);
            return View(ticketTurnoModel);
        }

        // GET: TicketTurnoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketTurnoModel = await _context.TicketTurnoList.FindAsync(id);
            if (ticketTurnoModel == null)
            {
                return NotFound();
            }

            ViewData["municipioID"] = new SelectList(_context.MunicipiosList, "ID", "descripcion", ticketTurnoModel.municipio);
            ViewData["asuntoID"] = new SelectList(_context.AsuntosList, "ID", "descripcion", ticketTurnoModel.asunto);
            ViewData["nivelID"] = new SelectList(_context.NivelesList, "ID", "descripcion", ticketTurnoModel.nivel);

            return View(ticketTurnoModel);
        }

        // POST: TicketTurnoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nombreRealiza,curp,nombre,paterno,materno,telefono,celular,correo")] TicketTurnoModel ticketTurnoModel)
        {
            if (id != ticketTurnoModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketTurnoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketTurnoModelExists(ticketTurnoModel.ID))
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

            ViewData["municipioID"] = new SelectList(_context.MunicipiosList, "ID", "descripcion", ticketTurnoModel.municipio);
            ViewData["asuntoID"] = new SelectList(_context.AsuntosList, "ID", "descripcion", ticketTurnoModel.asunto);
            ViewData["nivelID"] = new SelectList(_context.NivelesList, "ID", "descripcion", ticketTurnoModel.nivel);

            return View(ticketTurnoModel);
        }

        // GET: TicketTurnoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketTurnoModel = await _context.TicketTurnoList
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ticketTurnoModel == null)
            {
                return NotFound();
            }

            return View(ticketTurnoModel);
        }

        // POST: TicketTurnoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticketTurnoModel = await _context.TicketTurnoList.FindAsync(id);
            _context.TicketTurnoList.Remove(ticketTurnoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketTurnoModelExists(int id)
        {
            return _context.TicketTurnoList.Any(e => e.ID == id);
        }

        public async Task<IActionResult> Listadmin(string searchString, string nombreFiltro)
        {
            var tickets = from m in _context.TicketTurnoList
                          select m;

            if (!String.IsNullOrEmpty(searchString) || !String.IsNullOrEmpty(nombreFiltro))
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    tickets = tickets.Where(s => s.curp!.Contains(searchString));
                }else if (!String.IsNullOrEmpty(nombreFiltro))
                {
                    string[] name = nombreFiltro.Split(" ");
                    tickets = tickets.Where(s => s.nombre!.Contains(name[0]));
                    if(name.Length == 2)
                    {
                        tickets = tickets.Where(s => s.paterno!.Contains(name[1]));

                        if(name.Length == 3)
                        {
                            tickets = tickets.Where(s => s.paterno!.Contains(name[2]));
                        }
                    }
                }
                
        
                
            }

            return View(await tickets.ToListAsync());

            //return View(await _context.TicketTurnoList.ToListAsync());
        }



    }
}
