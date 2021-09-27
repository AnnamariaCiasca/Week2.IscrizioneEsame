//Creare una Console App che gestisca l’iscrizione ad un esame di uno Studente.
//Lo studente è definito con:
//• Nome
//• Cognome
//• AnnoDiNascita
//• Immatricolazione
//• Esami
//• RichiestaLaurea

//L’immatricolazione ha le seguenti caratteristiche:
//• Matricola
//• DataInizio
//• CorsoDiLaurea
//• FuoriCorso
//• CFUAccumulati

//Un Corso di laurea è dato da un
//• Nome,
//• AnniDiCorso,
//• i cfu per ottenere la laurea
//• una lista di corsi
//associati.

//Un Corso ha
//• un nome
//• dei CFU.


//Un Esame si riferisce ad un corso e tiene conto se esso è stato passato.


//I possibili nomi dei Corsi di Laurea possono essere solo i seguenti:
//Matematica, Fisica, Informatica, Ingegneria, Lettere.


//La matricola dello studente deve essere univoca, autogenerata e read-only.

//Uno studente può richiedere un esame solo se esso è presente nel Corso di Laurea associato allo studente,
//se i CFU del corso associato all’esame non superino i CFU massimi del Corso di laurea e se non ha il flag
//RichiestaLaurea assegnato a vero.
//Nel caso le condizioni siano verificate, lo studente aggiunge l’esame alla lista Esami.

//Scrivere inoltre un metodo EsamePassato che, dato un esame, vada ad aggiornare i CFU accumulati dallo
//studente, metta il flag Passato sull’esame e verifichi se con tale esame sono stati raggiunti i CFU necessari
//per richiedere la laurea (e quindi metta il flag Richiestalaurea a true)



using System;
using System.Collections.Generic;
using System.Linq;
using Week2.IscrizioneEsame.Core;
using Week2.IscrizioneEsame.Core.Entities;
using Week2.IscrizioneEsame.Mock;

namespace Week2.IscrizioneEsame
{
    public class Program
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new RepositoryCorsi(), new RepositoryCorsiDiLaurea(), new RepositoryImmatricolazione(), new RepositoryStudenti());
        static void Main(string[] args)
        {
            bool continua = true;
            bool uscita = true;
            int scelta;

            Studente s = new Studente();

            do
            {
                do
                {
                    Console.WriteLine("\nDigita 1 per immatricolarti");
                    Console.WriteLine("Digita 2 per accedere");
                    Console.WriteLine("Digita 3 per iscriverti ad un esame");
                    Console.WriteLine("Digita 0 per uscire");
                    continua = int.TryParse(Console.ReadLine(), out scelta);
                }
                while (!continua);


                switch (scelta)
                {
                    case 1:
                        s = FaiImmatricolazione();
                        break;
                    case 2:
                        Accedi();
                        break;
                    case 3:
                        Iscriviti(s);
                        break;
                    case 0:
                        uscita = false;
                        break;
                    default:
                        Console.WriteLine("Scelta errata");
                        break;
                }
            } while (uscita);
        }

        private static void Iscriviti(Studente s)
        {
            var immatricolazione = s._Immatricolazione;
            var corsoDiLaurea = immatricolazione._CorsoDiLaurea;
            var corsi = corsoDiLaurea.Corsi;

            foreach (var corso in corsi)
            {
                Console.WriteLine(corso.Print());
            }

            string esame = string.Empty;
            Corso corsoScelto;
            do
            {
                Console.WriteLine("A quale esame vuoi iscriverti?");
                esame = Console.ReadLine();
                corsoScelto = corsi.Where(c => c.Nome == esame).SingleOrDefault();

            } while (corsoScelto == null);
            bool possibileIscriversi = bl.VerificaCfuPerIscrizioneEsame(corsoScelto, s);
            // if (possibileIscriversi)
            //{
            //    Esame esameDaSostenere = new Esame();
            //    esameDaSostenere.Nome = corsoScelto.Nome;
            //    esameDaSostenere.Passato = false;
            //    esameDaSostenere.IdStudente = s.Id;

            //    esameDaSostenere = bl.AggiungiEsame(esameDaSostenere);


            //    bool esamePassato = bl.RandomEsamePassato(esameDaSostenere);
            //    if (esameDaSostenere.Passato)
            //    {
            //        bl.UpdateEsamePassato();
            //    }
            //}

        }

        private static void Accedi()
        {
            throw new NotImplementedException();
        }

        private static Studente FaiImmatricolazione()
        {
            string nome = string.Empty;
            bool continuare = true;

            do
            {
                Console.WriteLine("\nInserisci il tuo nome:");
                nome = Console.ReadLine();
                if (!String.IsNullOrEmpty(nome))
                {
                    continuare = false;
                }

            } while (continuare);

            string cognome = string.Empty;


            do
            {
                Console.WriteLine("\nInserisci il tuo cognome:");
                cognome = Console.ReadLine();
                if (!String.IsNullOrEmpty(cognome))
                {
                    continuare = false;
                }
                else
                {
                    continuare = true;
                }

            } while (continuare);




            int annoDiNascita;
            continuare = true;
            do
            {
                Console.WriteLine("\nInserisci il tuo anno di nascita:");
                continuare = int.TryParse(Console.ReadLine(), out annoDiNascita);
            } while (!continuare);


            Studente s = new Studente(nome, cognome, annoDiNascita);

            Console.WriteLine("\nEcco l'elenco dei Corsi di Laurea disponibili:\n");

            List<CorsoDiLaurea> corsidiLaurea = bl.FetchCorsiDiLaurea();
            foreach (var corsoDiLaurea in corsidiLaurea)
            {
                Console.WriteLine(corsoDiLaurea.Print());
            }
            CorsoDiLaurea cdl = new CorsoDiLaurea();
            do
            {
                Console.WriteLine("\nDigita il nome del corso a cui intendi iscriverti");
                var nomeCdL = Console.ReadLine();
                cdl = corsidiLaurea.Where(c => c.Nome == nomeCdL).SingleOrDefault();
            } while (cdl == null);

            s = bl.CreaImmatricolazione(s, cdl);

            return s;
        }
    }
}

