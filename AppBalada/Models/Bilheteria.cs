using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBalada.Models
{
    public class Bilheteria
    {
        public int BilheteriaId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Ingresso> Ingressos { get; set; }
    }
}