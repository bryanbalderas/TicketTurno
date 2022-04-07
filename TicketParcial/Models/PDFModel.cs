using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketParcial.Models
{
    public class PDFModel
    {
        public TicketTurnoModel TicketTurnoModel;
        public QRCodeModel QRCodeModel;

        public PDFModel(TicketTurnoModel ticketTurnoModel, QRCodeModel qrCodeModel)
        {
            TicketTurnoModel = ticketTurnoModel;
            QRCodeModel = qrCodeModel;
        }
    }
}
