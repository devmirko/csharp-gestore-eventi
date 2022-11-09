// See https://aka.ms/new-console-template for more information
using System.Runtime.ConstrainedExecution;

Console.WriteLine("Hello, World!");

//Per prima cosa è necessario creare una classe Evento che abbia i seguenti attributi: 
//●titolo 
//●data 
//●capienza massima dell’evento 
//●numero di posti prenotati 

public class Evento
{
    public string Titolo { get; set; }
    public DateTime Data { get; set; }

    public int PostiMax { get; set; }

    public int PostiPrenotati { get; set; }



}