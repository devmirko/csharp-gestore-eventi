// See https://aka.ms/new-console-template for more information
//Per prima cosa è necessario creare una classe Evento che abbia i seguenti attributi: 
//●titolo 
//●data 
//●capienza massima dell’evento 
//●numero di posti prenotati 

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
            _titolo = value;

        }
    }
    private DateTime _data;
    public DateTime Data {
        get {
            return _data;
        }
        set {
            if( DateTime.Now > value )
            {
                //inserire eccezzione
                _data = value;
            }
        }
    }

    private int _postiMax;

    public int PostiMax { 
        get {
            return _postiMax;
        } 
        set {
            _postiMax = value;
        } 
    }

    public int PostiPrenotati { get; private set; }


    public Evento(string titolo, DateTime data, int postiMax )
    {
      



    }

   



}