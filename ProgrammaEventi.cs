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

    public List<Evento> CercaEventi( DateTime data)
    {
        List<Evento> eventidata = new List<Evento>();
        foreach (Evento evento in eventi)
        {
            if (evento.Data == data)
            {
                eventidata.Add(evento);
            }
        }
        return eventidata;
    }

    //public static string StampaEventi(List<Evento> eventi)
    //{
    //    foreach ( Evento evento in eventi)
    //    {
            

    //    }

    //}



    





}







