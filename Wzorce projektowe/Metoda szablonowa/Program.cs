using System;

namespace Metoda_szablonowa
{
    abstract class ZamowienieTemplatka
    {

        public abstract void doKoszyk();
        public abstract void doPlatnosc();
        public abstract void doDostawa();

        public void dodanieGratisu()
        {
            Console.WriteLine("Dodano gratis...");
        }

        public void przetwarzajZamowienie(bool czyGratis)
        {
            doKoszyk();
            doPlatnosc();
            if (czyGratis)
            {
                dodanieGratisu();
            }
            doDostawa();
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
            Console.WriteLine();
        }

    }

    class ZamowienieStacjonarne : ZamowienieTemplatka
    {
        public override void doKoszyk()
        {
            Console.WriteLine("Wybranie produktów...");
        }

        public override void doPlatnosc()
        {
            Console.WriteLine("Płatność w kasie (karta/gotówka)...");
        }

        public override void doDostawa()
        {
            Console.WriteLine("Wydanie produktów (odbiór osobisty)...");
        }
    }


    class Program
    {
        public static void Main(string[] args)
        {
            ZamowienieTemplatka zamowienieOnline = new ZamowienieOnline();
            zamowienieOnline.przetwarzajZamowienie(true);

            ZamowienieTemplatka zamowienieStacjonarne = new ZamowienieStacjonarne();
            zamowienieStacjonarne.przetwarzajZamowienie(false);

        }
    }
}
