using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBalada.Models
{
    public class Ingresso
    {
        public int IngressoId { get; set; }
        public bool IsVip { get; set; }
        public int? PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
        public int BilheteriaId { get; set; }
        public Bilheteria Bilheteria { get; set; }
    }


}