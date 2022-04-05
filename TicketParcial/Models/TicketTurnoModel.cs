using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace TicketParcial.Models
{
    public class TicketTurnoModel
    {

        public int ID { get; set; }

        [Required]
        public string nombreRealiza { get; set; }

        [Required]
        public string curp { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public string paterno { get; set; }

        public string materno { get; set; }

        public int telefono { get; set; }

        public int celular { get; set; }

        public string correo { get; set; }

        public AsuntoModel asunto { get; set; }

        public MunicipioModel municipio { get; set; }

        public NivelModel nivel { get; set; }
    }
}
