using System;
using System.Collections.Generic;
using System.Linq;
using Week2.IscrizioneEsame.Core.Interfaces;

namespace Week2.IscrizioneEsame.Mock
{
    public class RepositoryCorsi : IRepositoryCorsi
    {
        public static List<Corso> corsi = new List<Corso>()
        {
            new Corso {Id = 1, Nome = "Analisi Matematica 1", CFU = 30, IdCorsoDiLaurea = 1},
            new Corso {Id = 2, Nome = "Geometria", CFU = 40, IdCorsoDiLaurea = 1},
            new Corso {Id = 3, Nome = "Analisi Matematica 2", CFU = 25, IdCorsoDiLaurea = 1},

            new Corso {Id = 4, Nome = "Fisica Teorica", CFU = 45, IdCorsoDiLaurea = 2},
            new Corso {Id = 5, Nome = "Termodinamica", CFU = 20, IdCorsoDiLaurea = 2},
            new Corso {Id = 6, Nome = "Meccanica", CFU = 40, IdCorsoDiLaurea = 2},

            new Corso {Id = 7, Nome = "Database", CFU = 20, IdCorsoDiLaurea = 3},
            new Corso {Id = 8, Nome = "Programmazione Procedurale", CFU = 35, IdCorsoDiLaurea = 3},
            new Corso {Id = 9, Nome = "Sistemi Operativi", CFU = 25, IdCorsoDiLaurea = 3},

            new Corso {Id = 10, Nome = "Automatica", CFU = 25, IdCorsoDiLaurea = 4},
            new Corso {Id = 11, Nome = "Elettrotecnica", CFU = 30, IdCorsoDiLaurea = 4},
            new Corso {Id = 12, Nome = "Analisi del Software", CFU = 40, IdCorsoDiLaurea = 4},

            new Corso {Id = 13, Nome = "Letteratura Greca", CFU = 45, IdCorsoDiLaurea = 5},
            new Corso {Id = 14, Nome = "Letteratura Latina", CFU = 35, IdCorsoDiLaurea = 5},
            new Corso {Id = 15, Nome = "Grammatica", CFU = 30, IdCorsoDiLaurea = 5},
        };

        public List<Corso> Fetch()
        {
            return corsi;
        }

        public List<Corso> GetCorsiByCdL(CorsoDiLaurea cdl)
        {
            corsi.Where(c => c.IdCorsoDiLaurea == cdl.Id).ToList();
            return corsi;
               
        }

        public void Insert(Corso item)
        {
            throw new NotImplementedException();
        }
    }
}
