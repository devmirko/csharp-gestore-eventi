// See https://aka.ms/new-console-template for more information
//Per prima cosa è necessario creare una classe Evento che abbia i seguenti attributi: 
//●titolo 
//●data 
//●capienza massima dell’evento 
//●numero di posti prenotati 
using csharp_gestore_eventi.Exceptions;

public class Evento 
{
    private string _titolo;
    public string Titolo
    {
        get
        {
            return _titolo;
        }
        set
        {
            if( value == null || value == "")
            {
                throw new GestoreEventiException("inserire il nome dell'evento");
            }
            _titolo = value;

        }
    }
    private DateTime _data;
    public DateTime Data
    {
        get
        {
            return _data;
        }
        set
        {
            if (DateTime.Now > value)
            {
                throw new GestoreEventiException("inserire un evento in data superiore a quella odierna");
                _data = value;
            }
        }
    }

    private int _postiMax;

    public int PostiMax
    {
        get
        {

            return _postiMax;
        }
         private set
        {
            if (value <= 0)
            {
                throw new GestoreEventiException("il numero di posti deve essere superiore a 1");
            }
            _postiMax = value;

        }
    }

    public int PostiPrenotati { get; private set; }


    public Evento(string titolo, DateTime data, int postiMax)
    {
        Titolo = titolo;
        Data = data;
        PostiMax = postiMax;
        PostiPrenotati = 0;


    }

    public void PrenotaPosti(int posti)
    {
        if( DisponibilitaPosti() < posti)
        {
            throw new GestoreEventiException("Non ci sono abbastanza posti diponibili per questo evento");
        }
        if( DateTime.Now > Data)
        {
            throw new GestoreEventiException("questo evento si è concluso");
        }
        PostiPrenotati += posti;

    }

    private int DisponibilitaPosti()
    {
        return PostiMax - PostiPrenotati;
    }

    public void DisdiciPosti(int posti)
    {
        if( posti < 1)
        {
            throw new GestoreEventiException("il numero di posti da disdire deve essere almeno 1");
        }
        if(DateTime.Now > Data)
        {
            throw new GestoreEventiException("Questo evento è terminato, non puoi disdire più le prenotazioni");
        }
        if (PostiPrenotati < posti)
        {
            throw new GestoreEventiException("Non puoi disdire più posti rispetto a quanti ne hai prenotati");
        }
        PostiPrenotati -= posti;
    }

    public override string ToString()
    {
        return Data.ToString() + " - " + Titolo;
    }

}
   

   



