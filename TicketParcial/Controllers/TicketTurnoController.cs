using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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


            var munic = from m in _context.MunicipiosList
                        select m;

            var asun = from m in _context.AsuntosList
                       select m;

            var niv = from m in _context.NivelesList
                      select m;

            var municip = munic.Where(s => s.ID!.Equals(ticketTurnoModel.municipioID)).ToList();

            var sunt = asun.Where(s => s.ID!.Equals(ticketTurnoModel.asuntoID)).ToList();

            var nive = niv.Where(s => s.ID!.Equals(ticketTurnoModel.nivelID)).ToList();

            AsuntoModel nasun = sunt[0];

            NivelModel nnivel = nive[0];

            MunicipioModel nmun = municip[0];

            ticketTurnoModel.municipio.descripcion = nmun.descripcion;

            ticketTurnoModel.nivel.descripcion = nnivel.descripcion;

            ticketTurnoModel.asunto.descripcion = nasun.descripcion;


            return View(ticketTurnoModel);
        }

        public async Task<int> NumeroMunTicketAsync(int idMunicipio)
        {
            var munic = from m in _context.TicketTurnoList
                        select m;

            munic = munic.Where(s => s.municipioID!.Equals(idMunicipio));


            var municipios = await munic.ToListAsync();




            int contador = municipios.Count();

            if (contador == 1)
            {
                return 1;
            }
            else
            {
                return contador + 1;
            }

           
        }

        public async Task<int> SiguienteTicketAsync()
        {
            var munic = from m in _context.TicketTurnoList
                        select m;



            var municipios = await munic.ToListAsync();




            int contador = municipios.Count();

            if (contador == 1)
            {
                ViewData["numeroTicket"] = 1;
                return 1;
            }
            else
            {
                return contador + 1;
            }


        }

        // GET: TicketTurnoModels/Create
        public IActionResult Create()
        {
            int sig = _context.TicketTurnoList.Count();

            ViewData["siguienteTurno"] = sig + 1;
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
                ticketTurnoModel.munTickID = await NumeroMunTicketAsync(ticketTurnoModel.municipioID);
                _context.Add(ticketTurnoModel);
                await _context.SaveChangesAsync();
                if (User.Identity.IsAuthenticated)
                {
                    return RedirectToAction(nameof(Listadmin));
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
                
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,nombreRealiza,curp,nombre,paterno,materno,telefono,celular,correo,asuntoID,municipioID,nivelID")] TicketTurnoModel ticketTurnoModel)
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
                if (User.Identity.IsAuthenticated)
                {
                    return RedirectToAction(nameof(Listadmin));
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            ViewData["municipioID"] = new SelectList(_context.MunicipiosList, "ID", "descripcion", ticketTurnoModel.municipio);
            ViewData["asuntoID"] = new SelectList(_context.AsuntosList, "ID", "descripcion", ticketTurnoModel.asunto);
            ViewData["nivelID"] = new SelectList(_context.NivelesList, "ID", "descripcion", ticketTurnoModel.nivel);

            return View(ticketTurnoModel);
        }

        [Authorize]
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
        [Authorize]
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

        [Authorize]
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
