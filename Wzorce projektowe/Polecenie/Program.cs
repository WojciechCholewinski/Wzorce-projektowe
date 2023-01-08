
using System;

public interface IPolecenie
{
    /* UZUPEŁNIĆ */
}

public class KomendaWlacz : IPolecenie
{
    Lampa lampa;
    public KomendaWlacz(Lampa lampa)
    {
        /* UZUPEŁNIĆ */
    }
    public void wykonaj()
    {
        lampa.wlacz();
    }
}

public class KomendaWylacz : IPolecenie
{
    /* UZUPEŁNIĆ */
}


public class Lampa
{
    /* UZUPEŁNIĆ */

    /* UZUPEŁNIĆ */

    public bool sprawdz()
    {
        return stan;
    }
}


public class Pilot
{
    private IPolecenie polecenie;

    /* UZUPEŁNIĆ */

}


class Program
{
    static void Main(string[] args)
    {
        /* UZUPEŁNIĆ */

        IPolecenie wlacz = new KomendaWlacz(lampa);
        /* UZUPEŁNIĆ */

        Console.WriteLine(lampa.sprawdz() ? "Lampa włączona" : "Lampa wyłączona");

        pilot.ustawPolecenie(wlacz);
        pilot.wcisnijGuzik();
        /* UZUPEŁNIĆ */

        pilot.ustawPolecenie(wylacz);
        pilot.wcisnijGuzik();
        /* UZUPEŁNIĆ */

    }
}