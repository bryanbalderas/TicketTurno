using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using TicketParcial.Infrastructure;
using TicketParcial.Models;
using QRCoder;
using System.Drawing;
using System.Diagnostics;
using System.Linq;

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

            var munic = from m in _context.MunicipiosList
                        select m;

            var asun = from m in _context.AsuntosList
                        select m;

            var niv = from m in _context.NivelesList
                        select m;

            var municip = munic.Where(s => s.ID!.Equals(ticketModel.municipioID)).ToList();

            var sunt = asun.Where(s => s.ID!.Equals(ticketModel.asuntoID)).ToList();

            var nive = niv.Where(s => s.ID!.Equals(ticketModel.nivelID)).ToList();

            AsuntoModel nasun = sunt[0];

            NivelModel nnivel = nive[0];

            MunicipioModel nmun = municip[0];

            ticketModel.municipio.descripcion = nmun.descripcion;

            ticketModel.nivel.descripcion = nnivel.descripcion;

            ticketModel.asunto.descripcion = nasun.descripcion;


            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeInfo = qrGenerator.CreateQrCode(ticketModel.curp, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeInfo);
            Bitmap qrBitmap = qrCode.GetGraphic(60);
            byte[] bitmapArray = qrBitmap.BitmapToByteArray();
            string qrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(bitmapArray));

            var qrCodeModel = new QRCodeModel(qrUri);
            var pdfModel = new PDFModel(ticketModel, qrCodeModel);

            return new ViewAsPdf("Index", pdfModel)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.Letter,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
            };
        }

    }
}
