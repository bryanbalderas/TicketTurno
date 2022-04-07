using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace TicketParcial.Models
{
    public class MunicipioModel
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "El campo municipio es requerido.")]
        [Display(Name = "Municipio", Prompt = "Ingresa un municipio")]
        public string descripcion { get; set; }


        public List<TicketTurnoModel> ticketList { get; set; }
    }
}
