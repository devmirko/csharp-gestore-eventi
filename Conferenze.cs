// See https://aka.ms/new-console-template for more information
//Per prima cosa è necessario creare una classe Evento che abbia i seguenti attributi: 
//●titolo 
//●data 
//●capienza massima dell’evento 
//●numero di posti prenotati 
using csharp_gestore_eventi.Exceptions;

public class Conferenze : Evento
{
    private string _relatore;
    public string Relatore { get {
            return _relatore;
        } 
        set {
            if (value == null || value == "")
            {
                throw new GestoreEventiException("inserire il nome del relatore");
            }
            _relatore = value;
        } 
    }

    private double _prezzo;

    public double Prezzo
    {
        get {
            return _prezzo;
        }
        set {
            if (value <= 0)
            {
                throw new GestoreEventiException("il prezzo deve essere superiore a 0");
            }
            _prezzo = value;
        }
    }

    public Conferenze(string titolo, DateTime data, int postiMax, string relatore, double prezzo ) : base(titolo, data, postiMax)
    {
        Relatore = relatore;
        Prezzo = prezzo;

    }

    public override string ToString()
    {
        return Data + "-" + Titolo + "-" + Relatore + "-" + Prezzo.ToString("0.00");

    }

}
   

   



