using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace TicketParcial.Models
{
    public class NivelModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "El campo nivel es requerido.")]
        [Display(Name = "Nivel", Prompt = "Ingresa un nivel")]
        public string descripcion { get; set; }

        public List<TicketTurnoModel> ticketList { get; set; }
    }
}
