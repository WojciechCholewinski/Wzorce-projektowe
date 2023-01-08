﻿using System;
using System.Collections.Generic;

public interface IUzytkownik
{
    void WyslijWiadomosc(string wiadomosc);
    void OdbierzWiadomosc(string wiadomosc);
}

public interface IMediator
{
    void DodajUzytkownika(IUzytkownik uzytkownik);
    void WyslijWiadomosc(string wiadomosc, IUzytkownik nadawca);
}

public class Mediator : IMediator
{
    List<IUzytkownik> uzytkownicy;
    public Mediator()
    {
        uzytkownicy = new List<IUzytkownik>();
    }

    public void DodajUzytkownika(IUzytkownik uzytkownik)
    {
        uzytkownicy.Add(uzytkownik);
    }

    public void WyslijWiadomosc(string wiadomosc, IUzytkownik nadawca)
    {
        foreach (IUzytkownik uzytkownik in uzytkownicy)
        {
            if (uzytkownik != nadawca)
            {
                uzytkownik.OdbierzWiadomosc(wiadomosc);
            }
        }
    }
}
public class Dev : IUzytkownik
{
    string login;
    IMediator Mediator;
    public Dev(IMediator Mediator, string login)
    {
        this.login = login;
        this.Mediator = Mediator;
    }

    public void WyslijWiadomosc(string wiadomosc)
    {
        Mediator.WyslijWiadomosc(wiadomosc, this);
    }

    public void OdbierzWiadomosc(string wiadomosc)
    {
        Console.WriteLine("Programista " + login + " otrzymał wiadomość: " + wiadomosc);
    }
}
public class Klient : IUzytkownik
{
    string login;
    IMediator Mediator;
    public Klient(IMediator Mediator, string login)
    {
        this.login = login;
        this.Mediator = Mediator;
    }

    public void WyslijWiadomosc(string wiadomosc)
    {
        Mediator.WyslijWiadomosc(wiadomosc, this);
    }
    public void OdbierzWiadomosc(string wiadomosc)
    {
        Console.WriteLine("Użytkownik " + login + " otrzymał wiadomość: " + wiadomosc);
    }
}

class Program
{
    static void Main(string[] args)
    {
        IMediator mediator = new Mediator();

        IUzytkownik nakamoto = new Dev(mediator, "Nakamoto");
        IUzytkownik geohot = new Dev(mediator, "Geohot");
        IUzytkownik ania = new Klient(mediator, "Ania");

        mediator.DodajUzytkownika(ania);
        mediator.DodajUzytkownika(nakamoto);
        mediator.DodajUzytkownika(geohot);


        ania.WyslijWiadomosc("Proszę natychmiast wprowadzić poprawki na produkcję.");
        geohot.WyslijWiadomosc("Czekam, aż Nakamoto zaparzy poranną kawę...");


    }
}