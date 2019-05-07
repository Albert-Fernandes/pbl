using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBalada.Models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }
        public virtual  ICollection<Ingresso>Ingressos { get; set; }

        public bool VerificaIdade()
        {
            bool IsMaior;
            if (Idade >= 18) 
            {
                IsMaior = true;
            }
            else
            {
                IsMaior = false;
            }
            return IsMaior;
        }
    }
}