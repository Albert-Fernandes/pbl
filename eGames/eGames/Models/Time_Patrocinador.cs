using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGames.Models
{
    public class Time_Patrocinador
    {
        public int Time_PatrocinadorId { get; set; }
        public int? TimeId { get; set; }
        public virtual Time Time { get; set; }
        public int? PatrocinadorId { get; set; }
        public virtual Patrocinador Patrocinador { get; set; }

    }
    }