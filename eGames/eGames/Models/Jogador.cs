using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGames.Models
{
    public enum Lane { Top,Mid,Jungle,Sup,Adc }
    public class Jogador
    {
        public int JogadorId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public string Elo { get; set; }
        public int? TimeId { get; set; }
        public virtual Time Time { get; set; }
    }
}