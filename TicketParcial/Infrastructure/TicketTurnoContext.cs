using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketParcial.Models;
using Microsoft.EntityFrameworkCore;

namespace TicketParcial.Infrastructure
{
    public class TicketTurnoContext:DbContext
    {
        public TicketTurnoContext(DbContextOptions<TicketTurnoContext>options)
            : base(options)
        {

        }

        public DbSet<TicketTurnoModel> TicketTurnoList { get; set; }

        public DbSet<MunicipioModel> MunicipiosList { get; set; }

        public DbSet<AsuntoModel> AsuntosList { get; set; }

        public DbSet<NivelModel> NivelesList { get; set; }

    }
}
