using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.IscrizioneEsame.Core.Interfaces;

namespace Week2.IscrizioneEsame.Core
{
    public class BusinessLayer: IBusinessLayer
    {
        private readonly IRepositoryCorsi corsiRep;
        private readonly IRepositoryCorsiDiLaurea corsiDiLaureaRep;

        public BusinessLayer(IRepositoryCorsi corsi, IRepositoryCorsiDiLaurea corsiDiLaurea)
        {
            corsiRep = corsi;
            corsiDiLaureaRep = corsiDiLaurea;
        }

        public List<CorsoDiLaurea> FetchCorsiDiLaurea()
        {
            return corsiDiLaureaRep.Fetch();
        }

        public void GetCorsi(CorsoDiLaurea cdl)
        {
            List<Corso> corsi = corsiRep.GetCorsiByCdL(cdl);
            cdl.Corsi = corsi;
            var cfuTot = corsi.Sum(c => c.CFU);
            cdl.CFUnecessari = cfuTot;
        }
    }
}
