using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.IscrizioneEsame.Core.Interfaces
{
    public interface IRepositoryCorsi : IRepository<Corso>
    {
        List<Corso> GetCorsiByCdL(CorsoDiLaurea cdl);
    }
}
