using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Pamiatka
{

    public interface IMovie
    {
        public void Restore(IMemento memento);
        public IMemento Save();
    }

    class BackToTheFuture : IMovie
    {
        private int Year;

        public BackToTheFuture(int year)
        {
            Console.WriteLine("Początkowy rok: " + year);
        }

        public void SetYear(int year)
        {
            this.Year = year;
            Console.WriteLine("Rok zmieniony na: " + year);
        }

        public IMemento Save()
        {
            Console.WriteLine("Zapisano pamiątkę z roku: " + this.Year);
            return new Memento(this.Year);
        }

        public void Restore(IMemento memento)
        {
            this.Year = memento.GetYear();
            Console.WriteLine("Przywrócony rok: " + this.Year);
            // przywraca wartość pola
            // print o przywróceniu
        }
    }

    public interface IMemento
    {
        public int GetYear();

    }

    class Memento : IMemento
    {
        private int Year;

        public Memento(int Year)
        {
            this.Year = Year;
        }

        public int GetYear()
        {
            return Year;
        }
    }

    class Caretaker
    {
        private List<IMemento> Mementos = new List<IMemento>();

        private IMovie movie;


        public Caretaker(IMovie movie)
        {
            this.movie = movie;
        }

        public void Save()
        {
            Mementos.Add(movie.Save());
            //?? :
            //Mementos.Add(
            // dodaje pamiętkę do listy pamiątek
        }

        public void Undo()
        {
            if (Mementos.Count == 0)
            {
                Console.WriteLine("Nie można cofnąć - brak zapisanych danych");
            }
            else
            {
                var memento = this.Mementos[this.Mementos.Count - 1];
                movie.Restore(memento);
                Mementos.RemoveAt(Mementos.Count - 1);
            }
            //var memento = this.Mementos[this.Mementos.Count - 1];

            // wyciągniętą pamiątkę trzeba skasować
            // i przywrócić (metoda)

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BackToTheFuture favoriteMovie = new BackToTheFuture(1985);
            Caretaker caretaker = new Caretaker(favoriteMovie);

            caretaker.Undo(); // test ;)

            Console.WriteLine();

            Console.WriteLine("Część I:");
            favoriteMovie.SetYear(1955);
            caretaker.Save();
            favoriteMovie.SetYear(1985);

            Console.WriteLine();

            Console.WriteLine("Część II:");
            favoriteMovie.SetYear(2015);
            favoriteMovie.SetYear(1985);
            caretaker.Undo();
            favoriteMovie.SetYear(1985);
            caretaker.Save();

            Console.WriteLine();

            Console.WriteLine("Część III:");
            favoriteMovie.SetYear(1885);
            caretaker.Undo();

        }
    }
}