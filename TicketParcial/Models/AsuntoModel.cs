using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace TicketParcial.Models
{
    public class AsuntoModel
    {

        public int ID { get; set; }

        [Required]
        public string descripcion { get; set; }

        public List<TicketTurnoModel> ticketList { get; set; }
    }
}
