// See https://aka.ms/new-console-template for more information
using csharp_gestore_eventi.Exceptions;


Console.WriteLine("Hello, World!");

Console.WriteLine("inizia a creare il tuo evento");
Console.WriteLine("inserisci il nome");
string nome = Console.ReadLine();
Console.WriteLine("inserisci la data del tuo evento (gg/mm/yyyy)");
string DataStringa = Console.ReadLine();
DateTime data = DateTime.Parse(DataStringa);
Console.WriteLine("inserisci la capienza massima");
int capienza = Convert.ToInt32(Console.ReadLine());



Evento evento = new Evento(nome, data, capienza);
Prenota();







void  Prenota()
{
    
    try
    {
        Console.WriteLine("quanti posti vuoi prenotare");
        int prenota = Convert.ToInt32(Console.ReadLine());
        evento.PrenotaPosti(prenota);
        Console.WriteLine("complimenti operazione riuscita con successo");
        bool prenotazione = true;
        if(prenotazione == true)
        {
            Console.WriteLine("Vuoi disdire delle prenotazioni?");
            string risposta = Console.ReadLine();
            if (risposta == "si")
            {
                Console.WriteLine("Quanti posti vuoi disdire?");
                int postidisdetti = Convert.ToInt32(Console.ReadLine());
                evento.DisdiciPosti(postidisdetti);


            }

        }
        Console.WriteLine("Numero di posti prenotati:" + evento.PostiPrenotati);
    }
    catch (GestoreEventiException e)
    {
        Console.WriteLine(e.ToString());
      

    }

   
}







