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

    public static string  StampaEventi(List<Evento> eventi)
    {
        string stampa = "";
        foreach ( Evento evento in eventi)
        {

            stampa = evento + "\n";



        }
        return stampa;



    }

    public int ContaEventi()
    {
        return eventi.Count();

    }

    public override string ToString()
    {
        string stampa = Titolo + "\n";
        foreach (Evento evento in eventi)
        {
            stampa = stampa + "\t" + evento.ToString() + "\n";
        }
        return stampa;
    }

    public void Elimina()
    {
        eventi.Clear();
    }













}







