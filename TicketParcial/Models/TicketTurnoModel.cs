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

        [Required(ErrorMessage = "El campo nombre de quien tramita es requerido.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre de quien tramita", Prompt = "Ingresa el nombre de quien tramita")]
        public string nombreRealiza { get; set; }

        [Required(ErrorMessage = "El campo curp es requerido.")]
        [DataType(DataType.Text)]
        [Display(Name = "CURP", Prompt = "Ingresa una CURP")]
        public string curp { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre", Prompt = "Ingresa un nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El campo paterno es requerido.")]
        [DataType(DataType.Text)]
        [Display(Name = "Paterno", Prompt = "Ingresa el apellido paterno")]
        public string paterno { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Materno", Prompt = "Ingresa el apellido materno")]
        public string materno { get; set; }

        [Phone(ErrorMessage = "El campo teléfono no cuenta con un téléfono válido.")]
        [Required(ErrorMessage = "El campo teléfono es requerido.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono", Prompt = "Ingresa un teléfono")]
        public int telefono { get; set; }

        [Phone(ErrorMessage = "El campo celular no cuenta con un celular válido.")]
        [Required(ErrorMessage = "El campo celular es requerido.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Celular", Prompt = "Ingresa un celular")]
        public int celular { get; set; }

        [Required(ErrorMessage = "El campo email es requerido.")]
        [EmailAddress(ErrorMessage = "El campo email no cuenta con un email válido.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email", Prompt = "Ingresa tu email")]
        public string correo { get; set; }

        [Required(ErrorMessage = "El campo asunto es requerido.")]
        [DataType(DataType.Text)]
        [Display(Name = "Asunto")]
        public AsuntoModel asunto { get; set; }
        [Required(ErrorMessage = "El campo municipio es requerido.")]
        [DataType(DataType.Text)]
        [Display(Name = "Municipio")]
        public MunicipioModel municipio { get; set; }
        [Required(ErrorMessage = "El campo nivel acádemico es requerido.")]
        [DataType(DataType.Text)]
        [Display(Name = "¿Nivel al que desea ingresar o que ya cursa el alumno?")]
        public NivelModel nivel { get; set; }
    }
}
