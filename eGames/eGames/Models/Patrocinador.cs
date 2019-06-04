using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGames.Models
{
    public class Patrocinador
    {
        public int PatrocinadorId { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public virtual ICollection<Time_Patrocinador>Time_Patrocinadores { get; set; }
    }
}