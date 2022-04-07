using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using TicketParcial.Infrastructure;
using TicketParcial.Models;

namespace TicketParcial.Controllers
{
    public class CrearPDFController : Controller
    {
        private readonly TicketTurnoContext _context;

        public CrearPDFController(TicketTurnoContext context)
        {
            _context = context;
        }

        // GET: Asunto/Details/5
        public async Task<IActionResult> Index(int? id) {

            if (id == null)
            {
                return NotFound();
            }

            var ticketModel = await _context.TicketTurnoList
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ticketModel == null)
            {
                return NotFound();
            }
            return new ViewAsPdf("Index", ticketModel)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.Letter,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
            };
        }
    }
}
