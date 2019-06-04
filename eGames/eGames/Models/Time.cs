using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGames.Models
{
    public class Time
    {
        public int TimeId { get; set; }
        public string Nome { get; set; }
        public int? Vitoria { get; set; }
        public bool IsVencedor { get; set; }
        public virtual ICollection<Jogador> Jogadores { get; set; }
        public int? PartidaId { get; set; }
        public virtual Partida Partida { get; set; }
        public virtual ICollection<Time_Patrocinador> Time_Patrocinadores { get; set; }
    }
}