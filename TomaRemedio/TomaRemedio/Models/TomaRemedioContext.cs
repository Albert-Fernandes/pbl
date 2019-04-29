using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TomaRemedio.Models
{
    public class TomaRemedioContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TomaRemedioContext() : base("name=TomaRemedioContext")
        {
        }

        public System.Data.Entity.DbSet<TomaRemedio.Receita> Receitas { get; set; }

        public System.Data.Entity.DbSet<TomaRemedio.Doenca> Doencas { get; set; }

        public System.Data.Entity.DbSet<TomaRemedio.Remedio> Remedios { get; set; }

        public System.Data.Entity.DbSet<TomaRemedio.RemedioDoenca> RemedioDoencas { get; set; }
    }
}
