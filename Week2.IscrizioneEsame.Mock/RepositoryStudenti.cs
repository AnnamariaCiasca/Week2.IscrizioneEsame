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
        public List<Studente> Fetch()
        {
            throw new NotImplementedException();
        }

        public void Insert(Studente item)
        {
            throw new NotImplementedException();
        }
    }
}
