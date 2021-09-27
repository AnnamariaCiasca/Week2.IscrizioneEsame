using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.IscrizioneEsame.Core.Interfaces;

namespace Week2.IscrizioneEsame.Mock
{
    public class RepositoryCorsiDiLaurea : IRepositoryCorsiDiLaurea
    {
        public static List<CorsoDiLaurea> corsiDiLaurea = new List<CorsoDiLaurea>()
        {
            new CorsoDiLaurea { Id = 1, Nome = "Matematica", AnniDiCorso = 3},
            new CorsoDiLaurea { Id = 2, Nome = "Fisica", AnniDiCorso = 3},
            new CorsoDiLaurea { Id = 3, Nome = "Informatica", AnniDiCorso = 3},
            new CorsoDiLaurea { Id = 4, Nome = "Ingegneria", AnniDiCorso = 3},
            new CorsoDiLaurea { Id = 5, Nome = "Lettere", AnniDiCorso = 3},
        };



        public List<CorsoDiLaurea> Fetch()
        {
            return corsiDiLaurea;
        }

    }
}
