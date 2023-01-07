using System;

namespace Metoda_szablonowa
{
    abstract class ZamowienieTemplatka
    {

        //
        //
        //

        public void dodanieGratisu()
        {
            Console.WriteLine("Dodano gratis...");
        }

        public void przetwarzajZamowienie(bool czyGratis)
        {
            //
            //
            //
        }
    }


    class ZamowienieOnline : ZamowienieTemplatka
    {

        override public void doKoszyk()
        {
            Console.WriteLine("Kompletowanie zamówienia...");
            Console.WriteLine("Ustawiono parametry wysyłki...");
        }

        override public void doPlatnosc()
        {
            Console.WriteLine("Płatność...");
        }

        override public void doDostawa()
        {
            Console.WriteLine("Wysyłka...");
        }

    }


    class Program
    {
        public static void Main(string[] args)
        {
            //
            //
            //

            ZamowienieTemplatka zamowienieStacjonarne = new ZamowienieStacjonarne();
            zamowienieStacjonarne.przetwarzajZamowienie(false);
        }
    }
}
