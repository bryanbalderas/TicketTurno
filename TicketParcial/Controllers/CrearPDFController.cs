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
