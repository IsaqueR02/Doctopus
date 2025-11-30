using Doctopus.Aplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctopus.Aplication.Data
{
    class AppDbContext: DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Evolucao> Evolucoes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;user=root;password=;database=doctopus_db";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect((connectionString)));
        }
    }
}
