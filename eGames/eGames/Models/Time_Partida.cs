using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGames.Models
{
    public class Time_Partida
    {
        public int Time_PartidaId { get; set; }
        public int? TimeId { get; set; }
        public virtual Time Time { get; set; }
        public int? PartidaId { get; set; }
        public virtual Partida Partida { get; set; }
    }
}