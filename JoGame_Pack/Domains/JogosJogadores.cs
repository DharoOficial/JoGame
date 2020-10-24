using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoGame_Pack.Domains
{
    public class JogosJogadores
    {
        public int JogosJogadoresId { get; set; }

        public virtual Jogo JogoIdNavigation { get; set; }
        public virtual Jogador PlayerIdNavigation { get; set; }
    }
}
    