using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUDPLANILLA.Models;

namespace CRUDPLANILLA.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<CRUDPLANILLA.Models.Usuario>? Usuario { get; set; }

        public DbSet<CRUDPLANILLA.Models.Planilla>? Planilla { get; set; }
    }
}
