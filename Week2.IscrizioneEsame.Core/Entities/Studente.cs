using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.IscrizioneEsame.Core.Entities;

namespace Week2.IscrizioneEsame
{
    public class Studente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int AnnoDiNascita { get; set; }
        public Immatricolazione _Immatricolazione { get; set; }
        public bool RichiestaLaurea { get; set; }
        public int IdImmatricolazione { get; set; }
        public List<Esame> Esami { get; set; }

        public Studente(string nome, string cognome, int annoDiNascita)
        {
            Nome = nome;
            Cognome = cognome;
            AnnoDiNascita = annoDiNascita;
        }

        public Studente()
        {
        }

        public void Print()
        {
            Console.WriteLine($"Studente: {Nome} - {Cognome} - {AnnoDiNascita} - {_Immatricolazione} - {Esami} - {RichiestaLaurea}");
        }

    }
}
