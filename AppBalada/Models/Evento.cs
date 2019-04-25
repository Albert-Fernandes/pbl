using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBalada.Models
{
    public class Evento
    {
        public int EventoId { get; set; }
        public string Nome { get; set; }
        public string Data { get; set; }
        public string Inicio { get; set; }
        public string Fim { get; set; }
        public bool IsRestrito { get; set; }
        public ICollection<Ingresso> Ingressos { get; set; }
    }
}