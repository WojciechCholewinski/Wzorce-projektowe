using System;
using System.Collections.Generic;

namespace Łańcuch_zobowiązań
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        void Handle(string request);
    }

    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual void Handle(string request)
        {
            if (_nextHandler != null)
            {
                _nextHandler.Handle(request);
            }
            else
            {
                Console.WriteLine($"Nikt nie chce tego zjeść: {request}");
            }
        }
    }

    public class MonkeyHandler : AbstractHandler
    {
        public override void Handle(string request)
        {
            if (request == "banan")
            {
                Console.WriteLine($"Małpa zjada {request}.");
            }
            else
            {
                base.Handle(request);
            }
        }
    }

    public class SquirrelHandler : AbstractHandler
    {
        public override void Handle(string request)
        {
            if (request == "orzech")
            {
                Console.WriteLine($"Wiewiórka zjada {request}.");
            }
            else
            {
                base.Handle(request);
            }
        }
    }

    public class DogHandler : AbstractHandler
    {
        public override void Handle(string request)
        {
            if (request == "mięso" || request == "plasterek szynki")
            {
                Console.WriteLine($"Pies zjada {request}.");
            }
            else
            {
                base.Handle(request);
            }
        }
    }

    public class CatHandler : AbstractHandler
    {
        public override void Handle(string request)
        {
            if (request == "mięso")
            {
                Console.WriteLine($"Kot zjada {request}.");
            }
            else
            {
                base.Handle(request);
            }
        }
    }

    public class Client
    {
        public static void ClientCode(AbstractHandler handler)
        {
            List<string> products = new List<string> { "orzech", "banan", "mięso", "plasterek szynki", "lody" };
            foreach (var product in products)
            {
                Console.WriteLine($"Kto chce {product}?");
                handler.Handle(product);
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            AbstractHandler monkey = new MonkeyHandler();
            AbstractHandler squirrel = new SquirrelHandler();
            AbstractHandler dog = new DogHandler();
            AbstractHandler cat = new CatHandler();

            monkey.SetNext(dog).SetNext(squirrel).SetNext(cat);
            squirrel.SetNext(cat);

            Console.WriteLine("Łańcuch: Małpa > Pies > Wiewiórka > Kot");
            Client.ClientCode
                (monkey);
            Console.WriteLine();

            Console.WriteLine("Podzbiór łańcucha: Wiewiórka > Kot");
            Client.ClientCode(squirrel);
        }
    }
}