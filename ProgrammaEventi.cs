// See https://aka.ms/new-console-template for more information
using csharp_gestore_eventi.Exceptions;

public class ProgrammaEventi
{
    private string _titolo;
    public string Titolo { 
        get {
            return _titolo;
        } 
        set {
            if( value == null | value == "")
            {
                throw new GestoreEventiException("inserire il nome dell'evento");
            }

            _titolo = value;
        } 
    }

    List<Evento> eventi;
    public ProgrammaEventi(string titolo)
    {
        Titolo = titolo;
        eventi = new List<Evento>();
    }

    public void AggiungiEvento( Evento evento )
    {
        eventi.Add(evento);

    }

    public List<Evento> CercaEventi( DateTime data )
    {
        List<Evento> eventidata = new List<Evento>();
        foreach (Evento evento in eventi)
        {
            if (evento.Data == data )
            {
                eventidata.Add(evento);
            }
        }
        return eventidata;
    }

    public Evento CercaEventoPrenotazione(DateTime data , string nome)
    {
        
        foreach (Evento evento in eventi)
        {
            if (evento.Data == data || evento.Titolo == nome )
            {
                return evento;
            }
        }
        return null;
    }

    public static string  StampaEvento(List<Evento> eventi)
    {
        string stampa = "";
        foreach ( Evento evento in eventi)
        {

            stampa = evento + "";



        }
        return stampa;



    }

    public int ContaEventi()
    {
        return eventi.Count();

    }

    public override string ToString()
    {
        string stampa = Titolo + "\r\n";
        foreach (Evento evento in eventi)
        {
            stampa = stampa + "-" + evento.ToString() + "\r\n";
        }
        return stampa;
    }

    public void Elimina()
    {
        eventi.Clear();
        Console.WriteLine("hai eliminato i tuoi eventi");
    }

    public static void ReadCsv()
    {
        Console.WriteLine("inserisci il nome del tuo programma di eventi");
        string nomeProgramma = Console.ReadLine();
        ProgrammaEventi programma = new ProgrammaEventi(nomeProgramma);
      
        StreamReader stream = File.OpenText("C:\\Users\\Utente\\source\\repos\\CorsoNet\\esercitazione_1\\csharp-gestore-eventi\\ProgrammiEventi.csv");
        while (!stream.EndOfStream)
        {
            string riga = stream.ReadLine();
            string[] space = riga.Split(";");
            if (space.Length == 6)
            {
                string titolo = space[0];
                DateTime data = DateTime.Parse(space[1]);
                int PostiMax = Convert.ToInt32(space[4]);
                Evento evento = new Evento(titolo, data, PostiMax);
                programma.AggiungiEvento(evento);
                

            }
        }

        stream.Close();
        programma.StampaProgramma();

    }

    public void StampaProgramma()
    {
        Console.WriteLine();
        Console.WriteLine(Titolo);
        StampaEvento(eventi);
    }















}







