using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.IscrizioneEsame.Core
{
    public interface IBusinessLayer
    {
        List<CorsoDiLaurea> FetchCorsiDiLaurea();
        void GetCorsi(CorsoDiLaurea cdl);
    }
}
