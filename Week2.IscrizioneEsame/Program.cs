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
using Week2.IscrizioneEsame.Mock;

namespace Week2.IscrizioneEsame
{
    public class Program
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new RepositoryCorsi(), new RepositoryCorsiDiLaurea());
        static void Main(string[] args)
        {
            var nome = Console.ReadLine();
            var cognome = Console.ReadLine();
            var annoDiNascita = int.Parse(Console.ReadLine());

            Studente s = new Studente(nome, cognome, annoDiNascita);

            List<CorsoDiLaurea> corsidiLaurea = bl.FetchCorsiDiLaurea();
            foreach(var corsoDiLaurea in corsidiLaurea)
            {
                Console.WriteLine(corsoDiLaurea.Print());
            }
            var nomeCdL = Console.ReadLine();

            var cdl = corsidiLaurea.Where(c => c.Nome == nomeCdL).SingleOrDefault();

            bl.GetCorsi(cdl);

        }
    }
}
