using System;
using System.Collections.Generic;

public interface Kompozyt
{
    //public int number { get; set; }

    void Renderuj();
    void DodajElement(Kompozyt element);
    void UsunElement(Kompozyt element);
}

public class Lisc : Kompozyt
{
    //Kompozyt kompozyt;
    //int number = 1;
    public string nazwa { get; set; }
    //int Kompozyt.number { get => kompozyt.number; set => kompozyt.number = value; }

    public void Renderuj()
    {
        //Console.WriteLine($"{nazwa}  {kompozyt.number} renderowanie...");
        Console.WriteLine($"{nazwa} renderowanie...");
    }


    public Lisc(string nazwa)
    {
        this.nazwa = nazwa;
    }

    public void DodajElement(Kompozyt element)
    {
        throw new NotImplementedException();
    }

    public void UsunElement(Kompozyt element)
    {
        throw new NotImplementedException();
    }

}


public class Wezel : Kompozyt
{
    //public int number = 1;

    private List<Kompozyt> Lista = new List<Kompozyt>();
    public string nazwa { get; set; }

    public void DodajElement(Kompozyt element)
    {
        Lista.Add(element);
    }
    //public Wezel(List<Kompozyt> lista, string nazwa)
    //{
    //    Lista = lista;
    //    this.nazwa = nazwa;
    //}
    public Wezel(string nazwa)
    {
        this.nazwa = nazwa;
    }

    public void Renderuj()
    {
        Console.WriteLine(nazwa + " rozpoczęcie renderowania");
        //rozpoczęcie renderowania

        foreach (var item in Lista)
        {
            item.Renderuj();
        }
        //foreach item.Renderuj(); 

        //zakończenie renderowania
        Console.WriteLine(nazwa + " zakończenie renderowania");
    }

    public void UsunElement(Kompozyt element)
    {
        Lista.Remove(element);
    }


}


class MainClass
{
    public static void Main(string[] args)
    {
        //Wezel all = new Wezel("0");
        //void load()
        //{
        //    all = new Wezel("0");
        //    all.DodajElement(new Wezel("Węzeł"));
        //    all.DodajElement(new Wezel("Węzeł 2"));
        //    all.DodajElement(new Wezel("Węzeł 3"));
        //    all.DodajElement(new Wezel("Węzeł 33"));

        //}

        //void groupSelected(Kompozyt[] components)
        //{
        //    Wezel group = new Wezel("wezel000");
        //    foreach (var component in components)
        //    {
        //        group.DodajElement(component);
        //        group.UsunElement(component);
        //    }
        //    all.DodajElement(group);
        //    all.Renderuj();
        //};





        Kompozyt korzen = new Wezel("Korzeń");
        //Kompozyt lisc = new Lisc("Liść");
        Kompozyt lisc1 = new Lisc("Liść 1.1");
        Kompozyt lisc2 = new Lisc("Liść 2.1");
        Kompozyt lisc3 = new Lisc("Liść 2.2");
        Kompozyt lisc4 = new Lisc("Liść 2.3");
        Kompozyt lisc5 = new Lisc("Liść 3.1");
        Kompozyt lisc6 = new Lisc("Liść 3.2");
        Kompozyt lisc7 = new Lisc("Liść 3.3.1");
        Kompozyt wezel2 = new Wezel("Węzeł 2");
        Kompozyt wezel3 = new Wezel("Węzeł 3");
        Kompozyt wezel33 = new Wezel("Węzeł 3.3");



        korzen.DodajElement(lisc1);

        korzen.DodajElement(wezel2);
        wezel2.DodajElement(lisc2);
        wezel2.DodajElement(lisc3);
        wezel2.DodajElement(lisc4);

        korzen.DodajElement(wezel3);
        wezel3.DodajElement(lisc5);
        wezel3.DodajElement(lisc6);
        wezel3.DodajElement(wezel33);
        wezel33.DodajElement(lisc7);

        korzen.Renderuj();







    }

    //    using System;
    //using System.Collections.Generic;

    //public interface Kompozyt
    //{
    //    //
    //    void DodajElement(Kompozyt element);
    //    void UsunElement(Kompozyt element);
    //}

    //public class Lisc : Kompozyt
    //{

    //    public string nazwa { get; set; }

    //    public void Renderuj()
    //    {
    //        // renderowanie
    //    }


    //    // konstruktor

    //    // 2 brakujące metody których wymaga interfejs

    //}


    //public class Wezel : Kompozyt
    //{

    //    private List<Kompozyt> Lista = new List<Kompozyt>();

    //    public string nazwa { get; set; }

    //    public void Renderuj()
    //    {
    //        //rozpoczęcie renderowania

    //        //foreach item.Renderuj(); 

    //        //zakończenie renderowania
    //    }

    //    // 2 brakujące metody 

    //}


    //class MainClass
    //{
    //    public static void Main(string[] args)
    //    {

    //        //
    //        //  definicje struktury
    //        //

    //        korzen.Renderuj();

    //    }
    //}
}