using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.IscrizioneEsame
{
    public class Immatricolazione
    {
        public int Matricola { get; }
        public DateTime DataInizio { get; set; }
        public CorsoDiLaurea _CorsoDiLaurea { get; set; }
        public bool FuoriCorso { get; set; }
        public int CFUaccumumulati { get; set; }



     

        public string GetInfo()
        {

            return $"{Matricola}, {DataInizio}, {_CorsoDiLaurea}, {FuoriCorso},{ CFUaccumumulati}";


        }



    }
}
