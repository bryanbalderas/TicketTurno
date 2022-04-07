using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using TicketParcial.Models;

namespace TicketParcial.Controllers
{
    public class CrearPDFController : Controller
    {
       
        public IActionResult Index() {
            
            var ticket = new TicketTurnoModel()
            {
                ID = 1,
                nombreRealiza = "juanita",
                curp = "MOBJ790616HCLNSX04",
                nombre = "hola",
                paterno = "monjaras",
                materno = "granados",
                telefono = "8444103251",
                celular = "8444103251",
                correo = "example@example.com"

            };

            return new ViewAsPdf("Index", ticket)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.Letter,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                //FileName = "Detalle_ticket.pdf"
            };

           
        }
    }
}
