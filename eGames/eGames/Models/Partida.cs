﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGames.Models
{
    public class Partida
    {
        public int PartidaId { get; set; }
        public string Premiacao { get; set; }
        public String TempoPartida { get; set; }
        public virtual ICollection<Time>Times { get; set; }
    }
}