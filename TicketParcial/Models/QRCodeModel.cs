using System.ComponentModel.DataAnnotations;

namespace TicketParcial.Models
{
    public class QRCodeModel
    {
        public string QRCodeURI { get; set; }

        public QRCodeModel(string qrCodeURI)
        {
            QRCodeURI = qrCodeURI;
        }
    }
}