using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.IscrizioneEsame.Core.Interfaces;

namespace Week2.IscrizioneEsame.Core.RepositoryInterface
{
    public interface IRepositoryImmatricolazione : IRepository<Immatricolazione>
    {
        Immatricolazione GetByDate(Immatricolazione imm);
    }
}
