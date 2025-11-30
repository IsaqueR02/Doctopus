using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doctopus.Aplication.Models
{
    public class Evolucao
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataAtendimento { get; set; }
        [Required]
        public string Descricao { get; set; }
        public int NotaParticipacao { get; set; }
        public int PacienteId { get; set; }

        [ForeignKey("PacienteId")]
        public virtual Paciente Paciente { get; set; }

        public int ProfissionalId { get; set; }

        [ForeignKey("ProfissionalId")]
        public virtual Profissional Profissional { get; set; }
    }
}
