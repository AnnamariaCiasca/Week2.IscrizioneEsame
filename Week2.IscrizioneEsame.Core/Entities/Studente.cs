using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.IscrizioneEsame
{
    public class Studente
    {
  
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int AnnoDiNascita { get; set; }
        public Immatricolazione _Immatricolazione { get; set; }
        public string Esami { get; set; }
        public bool RichiestaLaurea { get; set; }


        public Studente(string nome, string cognome, int annoDiNascita)
        {
            Nome = nome;
            Cognome = cognome;
            AnnoDiNascita = annoDiNascita;
        }




        public void StampaStudente()
        {
            Console.WriteLine($"Studente: {Nome} - {Cognome} - {AnnoDiNascita} - {_Immatricolazione} - {Esami} - {RichiestaLaurea}");
        }

    }
}
