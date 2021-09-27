using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.IscrizioneEsame.Core.RepositoryInterface;

namespace Week2.IscrizioneEsame.Mock
{
    public class RepositoryStudenti : IRepositoryStudenti
    {
        public static List<Studente> studenti = new List<Studente>();
        public List<Studente> Fetch()
        {
            throw new NotImplementedException();
        }

        public void Insert(Studente item)
        {
            if (studenti.Count() == 0)
            {
                item.Id = 1;
            } 
                else
                {
                item.Id = studenti.Max(s => s.Id) + 1;
            }
            studenti.Add(item);
            }
        }
    }

