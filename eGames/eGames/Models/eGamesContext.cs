using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eGames.Models
{
    public class eGamesContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public eGamesContext() : base("name=eGamesContext")
        {
        }

        public System.Data.Entity.DbSet<eGames.Models.Jogador> Jogadors { get; set; }

        public System.Data.Entity.DbSet<eGames.Models.Time> Times { get; set; }

        public System.Data.Entity.DbSet<eGames.Models.Partida> Partidas { get; set; }

        public System.Data.Entity.DbSet<eGames.Models.Patrocinador> Patrocinadors { get; set; }

        public System.Data.Entity.DbSet<eGames.Models.Time_Patrocinador> Time_Patrocinador { get; set; }
    }
}
