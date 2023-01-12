using System;


public interface ITelewizor
{
    string Name { get; set; }
    int Kanal { get; set; }
    void Wlacz();
    void Wylacz();
    void ZmienKanal(int kanal);
}



public class TvLg : ITelewizor
{
    public string Name { get; set; } = "LG";

    public TvLg()
    {
        this.Kanal = 1;
    }

    public int Kanal { get; set; }

    public void Wlacz()
    {
        Console.WriteLine("Telewizor LG - włączam się.");
    }

    public void Wylacz()
    {
        Console.WriteLine("Telewizor LG - wyłączam się.");
        //
    }

    public void ZmienKanal(int kanal)
    {
        Kanal = kanal;
        Console.WriteLine("Telewizor LG - zmianiam kanał: " + Kanal);

    }

}
public class TvXiaomi : ITelewizor
{
    public string Name { get; set; } = "Xiaomi";
    public TvXiaomi()
    {
        this.Kanal = 1;
    }

    public int Kanal { get; set; }

    public void Wlacz()
    {
        Console.WriteLine("Telewizor Xiaomi - włączam się.");
    }

    public void Wylacz()
    {
        Console.WriteLine("Telewizor Xiaomi - wyłączam się.");
        //
    }

    public void ZmienKanal(int kanal)
    {
        Kanal = kanal;
        Console.WriteLine("Telewizor Xiaomi - zmianiam kanał: " + Kanal);

    }

}



public abstract class PilotAbstrakcyjny
{

    private ITelewizor tv;

    public PilotAbstrakcyjny(ITelewizor tv)
    {
        this.tv = tv;
    }

    public void Wlacz()
    {
        tv.Wlacz();
    }

    public void Wylacz()
    {
        tv.Wylacz();
    }


    public void ZmienKanal(int kanal)
    {
        tv.Kanal = kanal;
        Console.WriteLine("Telewizor " + tv.Name + " - zmieniam kanał: " + kanal);
    }

}



public class PilotHarmony : PilotAbstrakcyjny
{

    public PilotHarmony(ITelewizor tv) : base(tv) { }

    public void DoWlacz()
    {
        Console.WriteLine("Pilot Harmony - włącz telewizor...");
        Wlacz();
    }
    public void DoWylacz()
    {
        Console.WriteLine("Pilot Harmony - wyłącz telewizor...");
        Wylacz();
    }
    public void DoZmienKanal(int kanal)
    {
        Console.WriteLine("Pilot Harmony - zmienia kanał...");
        ZmienKanal(kanal);
    }


}

public class PilotLG : PilotAbstrakcyjny
{

    public PilotLG(ITelewizor tv) : base(tv) { }

    public void DoWlacz()
    {
        Console.WriteLine("Pilot LG - włącz telewizor...");
        Wlacz();
    }
    public void DoWylacz()
    {
        Console.WriteLine("Pilot LG - wyłącz telewizor...");
        Wylacz();

    }
    public void DoZmienKanal(int kanal)
    {
        Console.WriteLine("Pilot LG - zmienia kanał...");
        ZmienKanal(kanal);

    }


}



class MainClass
{
    public static void Main(string[] args)
    {

        ITelewizor tv = new TvLg();

        PilotHarmony pilotHarmony = new PilotHarmony(tv);
        pilotHarmony.DoWlacz();
        Console.WriteLine("Sprawdź kanał - bieżący kanał: " + tv.Kanal);

        PilotLG pilotLG = new PilotLG(tv);
        pilotLG.DoZmienKanal(100);
        Console.WriteLine("Sprawdź kanał - bieżący kanał: " + tv.Kanal);
        pilotHarmony.DoWylacz();

    }
}