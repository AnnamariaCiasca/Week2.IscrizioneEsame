using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.IscrizioneEsame.Core.Interfaces;
using Week2.IscrizioneEsame.Core.RepositoryInterface;

namespace Week2.IscrizioneEsame.Core
{
    public class BusinessLayer: IBusinessLayer
    {
        private readonly IRepositoryCorsi corsiRep;
        private readonly IRepositoryCorsiDiLaurea corsiDiLaureaRep;
        private readonly IRepositoryImmatricolazione immatricolazioneRep;
        private readonly IRepositoryStudenti studentiRep;

        public BusinessLayer(IRepositoryCorsi corsi, IRepositoryCorsiDiLaurea corsiDiLaurea, IRepositoryImmatricolazione immatricolazioni, IRepositoryStudenti studenti)
        {
            corsiRep = corsi;
            corsiDiLaureaRep = corsiDiLaurea;
            immatricolazioneRep = immatricolazioni;
            studentiRep = studenti;
        }

        public Studente CreaImmatricolazione(Studente s, CorsoDiLaurea cdl)
        {
            Immatricolazione imm = new Immatricolazione();
            imm.DataInizio = DateTime.Now;
            imm._CorsoDiLaurea = GetCorsi(cdl);
           
          
            int ore = imm.DataInizio.Hour;
            int minuti = imm.DataInizio.Minute;
            int secondi = imm.DataInizio.Second;

           var matricola = String.Concat(ore, minuti, secondi);
           imm.Matricola = Convert.ToInt32(matricola);

            immatricolazioneRep.Insert(imm);
            imm = immatricolazioneRep.GetByDate(imm);

            s._Immatricolazione = imm;
            return s;
        }

        public List<CorsoDiLaurea> FetchCorsiDiLaurea()
        {
            return corsiDiLaureaRep.Fetch();
        }

        public CorsoDiLaurea GetCorsi(CorsoDiLaurea cdl)
        {
            List<Corso> corsi = corsiRep.GetCorsiByCdL(cdl);
            cdl.Corsi = corsi;
            var cfuTot = corsi.Sum(c => c.CFU);
            cdl.CFUnecessari = cfuTot;
            return cdl;
        }

       
    }
}
