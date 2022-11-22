using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            zoo.Work();
        }
    }

    class Zoo
    {
        private Aviary[] _aviaries;

        public Zoo()
        {
            _aviaries = new Aviary[] {new Aviary("Клетка с тиграми", "тигр", "рычание", 2), new Aviary("Клетка с жирафами", "жираф", "топот жирафов", 2), new Aviary("Загон с овцами", "овца", "блеяние", 6), new Aviary("Клетка с попугаями", "попугай", "чириканье", 8) };
        }

        public void Work()
        {
            bool isFinish = false;

            while(isFinish == false)
            {
                Console.Clear();

                for (int i = 0; i < _aviaries.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {_aviaries[i].Name}");
                }

                int input = ReadInt("Выберите вольер: ");

                if (input > 0 && input <= _aviaries.Length)
                    _aviaries[input - 1].ShowInfo();
                else
                    Console.Clear();
            }
        }

        private int ReadInt(string text)
        {
            bool isNumber = false;
            int result = 0;

            while (isNumber == false)
            {
                Console.Write(text);

                if (int.TryParse(Console.ReadLine(), out result))
                    isNumber = true;
            }

            return result;
        }
    }

    class Aviary
    {
        private Animal[] _animals;
        private string _sound;
        private Random _random;
        public string Name { get; private set; }

        public Aviary(string name, string animalsName, string sound, int animalsCount)
        {
            _random = new Random();
            _animals = AddAnimals(animalsName, animalsCount);
            Name = name;
            _sound = sound;
        }

        public void ShowInfo()
        {
            Console.Clear();
            Console.WriteLine($"{Name}\nВы слышите: {_sound}\nКоличество животныйх: {_animals.Length}");

            foreach(var animal in _animals)
            {
                animal.ShowInfo();
            }

            Console.ReadKey();
        }

        private Animal[] AddAnimals(string animalsName, int animalsCount)
        {
            Animal[] animals = new Animal[animalsCount];
            string[] genderVariant = new string[2] {"самец", "самка"};

            for(int i = 0; i < animalsCount; i++)
            {
                animals[i] = new Animal(genderVariant[_random.Next(genderVariant.Length)], animalsName);
            }

            return animals;
        }
    }

    class Animal
    {
        private string _gender;
        private string _name;

        public Animal(string gender, string name)
        {
            _gender = gender;
            _name = name;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_name} - {_gender}");
        }
    }
}
