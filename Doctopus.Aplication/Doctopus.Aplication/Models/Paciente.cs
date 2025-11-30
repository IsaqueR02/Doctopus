using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctopus.Aplication.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NomeCompleto { get; set; }

        public DateTime DataNascimento { get; set; }

        public string NomeResponsavel { get; set; }

        public string Diagnostico { get; set; }

        public string PlanoSaude { get; set; }

        public string NumeroCarteirinha { get; set; }

        public string Interesses { get; set; }

        public string SensibilidadeSensorial { get; set; }
    }
}