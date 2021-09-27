using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.IscrizioneEsame
{
    public class Corso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CFU { get; set; }

        public int IdCorsoDiLaurea { get; set; }

        public string Print()
        {
            return $"Nome: {Nome} - CFU: {CFU}";
        }
    }
}
