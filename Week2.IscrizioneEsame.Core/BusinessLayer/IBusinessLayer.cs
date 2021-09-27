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
        CorsoDiLaurea GetCorsi(CorsoDiLaurea cdl);
        Studente CreaImmatricolazione(Studente s, CorsoDiLaurea cdl);
    }
}
