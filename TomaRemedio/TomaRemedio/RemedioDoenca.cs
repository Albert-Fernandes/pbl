//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TomaRemedio
{
    using System;
    using System.Collections.Generic;
    
    public partial class RemedioDoenca
    {
        public int Id { get; set; }
        public int RemediosId { get; set; }
        public int DoencaId { get; set; }
        public int RemedioId { get; set; }
    
        public virtual Doenca Doenca { get; set; }
        public virtual Remedio Remedio { get; set; }
    }
}
