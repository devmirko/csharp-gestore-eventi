// See https://aka.ms/new-console-template for more information
using csharp_gestore_eventi.Exceptions;


Console.WriteLine("Hello, World!");

Console.WriteLine("inizia a creare il tuo evento");
Console.WriteLine("inserisci il nome del tuo programma di eventi");
string nomeProgramma = Console.ReadLine();

Console.WriteLine("inserisci il numero di eventi da inserire");
int NumeroEventi = Convert.ToInt32(Console.ReadLine());
ProgrammaEventi programma = new ProgrammaEventi(nomeProgramma);
for (int i = 1; i < NumeroEventi + 1; i++)
{
    NewEvento(i);
    
}

//menu per la prenotazione
bool exit = true;
do
{
    Console.WriteLine("1 - Numero Eventi presenti nel programma");
    Console.WriteLine("2 - Lista Eventi presenti nel programma");
    Console.WriteLine("3 - Ricerca un evento per una data");
    Console.WriteLine("4 - Prenota per un evento");
    Console.WriteLine("5 - Elimina una prenotazione");
    Console.WriteLine("6 - Elimina il tuo programma di eventi");
    Console.WriteLine("7 - Esci");

    string sceltaUtente = Console.ReadLine();
    switch (sceltaUtente)
    {
        case "1":
            Console.WriteLine("il numero di eventi presenti nel tuo programma:" + programma.Titolo + ":" + programma.ContaEventi());
            break;
        case "2":
            Console.WriteLine(programma.ToString());

            break;
        case "3":
            try {
                Console.WriteLine("inserisci una data per cercare un evento");
                string DataStringa = Console.ReadLine();
                DateTime data = DateTime.Parse(DataStringa);
                List<Evento> eventi = programma.CercaEventi(data);
                Console.WriteLine(ProgrammaEventi.StampaEvento(eventi));
            } catch (GestoreEventiException e)
            {
                Console.WriteLine(e.Message);


            }
            break;
        case "4":
            try
            {
                Console.WriteLine("inserisci una nome di un evento");
                string name = Console.ReadLine();
                Console.WriteLine("inserisci una data per cercare un evento");
                string DataStringa = Console.ReadLine();
                DateTime data = DateTime.Parse(DataStringa);
                Evento evento = programma.CercaEventoPrenotazione(data,name);
                Prenota(evento);
            }
            catch (GestoreEventiException e)
            {
                Console.WriteLine(e.Message);


            }
            break;
        case "5":
            try
            {
                Console.WriteLine("inserisci una nome di un evento");
                string name = Console.ReadLine();
                Console.WriteLine("inserisci una data per cercare un evento");
                string DataStringa = Console.ReadLine();
                DateTime data = DateTime.Parse(DataStringa);
                Evento evento = programma.CercaEventoPrenotazione(data, name);
                EliminaPrenotazione(evento);
            }
            catch (GestoreEventiException e)
            {
                Console.WriteLine(e.Message);


            }
            break;
        case "6":
            Console.WriteLine("sei sicuro di voler eliminare la tua lista di eventi(si o no)");
            string risposta = Console.ReadLine();
            if(risposta == "si") {
                programma.Elimina();
            }
            
            break;


        default:
            exit = false;
            break;
    }




} while (exit);











 void  Prenota(Evento evento)
 {
    
   try
   {
           Console.WriteLine("posti disponibili per questo evento:" + (evento.PostiMax - evento.PostiPrenotati));
           Console.WriteLine("quanti posti vuoi prenotare");
           int prenota = Convert.ToInt32(Console.ReadLine());
           evento.PrenotaPosti(prenota);
           Console.WriteLine("complimenti operazione riuscita con successo");
       
    }
    catch (GestoreEventiException e)
    {
           Console.WriteLine(e.ToString());


    }


 }

void NewEvento(int numero)
{
    Console.WriteLine("inserisci il nome del tuo " + numero +   "°evento" );
    string nome = Console.ReadLine();
    Console.WriteLine("inserisci la data del tuo evento (gg/mm/yyyy)");
    string DataStringa = Console.ReadLine();
    DateTime data = DateTime.Parse(DataStringa);
    Console.WriteLine("inserisci la capienza massima");
    int totaleposti = Convert.ToInt32(Console.ReadLine());
    try
    {
        Evento evento = new Evento(nome, data, totaleposti);
        programma.AggiungiEvento(evento);


    }
    catch(GestoreEventiException e)
    {
        Console.WriteLine(e.Message);

    }



}

void EliminaPrenotazione(Evento evento)
{
    try
    {
        Console.WriteLine("posti prenotati per questo evento" + evento.PostiPrenotati);
        Console.WriteLine("quanti posti vuoi disdire");
        int disdici = Convert.ToInt32(Console.ReadLine());
        evento.DisdiciPosti(disdici);
        Console.WriteLine("complimenti operazione riuscita con successo");

    }
    catch (GestoreEventiException e)
    {
        Console.WriteLine(e.ToString());


    }


}











