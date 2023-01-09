using System;

interface Stan
{

    void alert();

}

class Powiadomienia
{

    private Stan aktualnyStan;

    public Powiadomienia()
    {
        aktualnyStan = //domyślny
  }

    //ustawStan(Stan stan)
    //

    //
    //

}

class Dzwonek : Stan
{

    //

}



class Program
{
    public static void Main(string[] args)
    {
        //
        //
        //
        //
        //
        //
        powiadomienia.alert();
        powiadomienia.ustawStan(new Wibracja());
        powiadomienia.alert();
    }
}