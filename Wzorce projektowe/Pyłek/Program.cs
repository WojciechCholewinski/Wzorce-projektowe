using System;
using System.Collections.Generic;

namespace Pylek
{
    public enum Type { LargeTree, Tree, Bush }
    public interface Plant
    {
        void Display(int positionX, int positionY);
    }
    public class LargeTree : Plant
    {
        private string Texture = "large_tree.png";
        public void Display(int x, int y)
        {
            Console.WriteLine($"Duże drzewo (plik \"{Texture}\") znajduje się na pozycji {x},{y}");
        }
    }
    public class Tree : Plant
    {
        private string Texture = "tree.png";
        public void Display(int x, int y)
        {
            Console.WriteLine($"Normalne drzewo (plik \"{Texture}\") znajduje się na pozycji {x},{y}");
        }
    }
    public class Bush : Plant
    {
        private string Texture = "bush.png";
        public void Display(int x, int y)
        {
            Console.WriteLine($"Krzak (plik \"{Texture}\") znajduje się na pozycji {x},{y}");
        }
    }
    public class PlantFactory
    {
        private Dictionary<Type, Plant> Plants = new Dictionary<Type, Plant>();

        public Plant GetPlant(Type type)
        {
            Plant plant = null;
            if (Plants.ContainsKey(type))
            {
                plant = Plants[type];
                Console.WriteLine("Wykorzystuję istniejący obiekt");
            }
            else
            {
                Console.WriteLine($"Tworzę nowy obiekt typu {type}");
                switch (type)
                {
                    case Type.Tree:
                        plant = new Tree();
                        break;
                    case Type.LargeTree:
                        plant = new LargeTree();
                        break;
                    case Type.Bush:
                        plant = new Bush();
                        break;
                }
                Plants.Add(type, plant);
            }
            return plant;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new PlantFactory();

            var plant = factory.GetPlant(Type.Tree);
            plant.Display(0, 0);
            Console.WriteLine("");
            plant = factory.GetPlant(Type.LargeTree);
            plant.Display(0, 7);
            Console.WriteLine("");
            plant = factory.GetPlant(Type.Tree);
            plant.Display(3, 16);
            Console.WriteLine("");
            plant = factory.GetPlant(Type.Bush);
            plant.Display(10, 9);
            Console.WriteLine("");
            plant = factory.GetPlant(Type.Tree);
            plant.Display(7, 7);
            Console.WriteLine("");
            plant = factory.GetPlant(Type.LargeTree);
            plant.Display(20, 0);
            Console.WriteLine("");
            plant = factory.GetPlant(Type.Tree);
            plant.Display(3, 28);
            Console.WriteLine("");
            plant = factory.GetPlant(Type.Bush);
            plant.Display(1, 5);
            Console.WriteLine("");
            plant = factory.GetPlant(Type.Tree);
            plant.Display(8, 8);
        }
    }
}