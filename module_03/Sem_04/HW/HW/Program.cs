using System;
using System.Collections.Generic;

namespace HW
{

    class Program
    {
        public abstract class Creature
        {
            public abstract string Name { get; set; }
            public abstract string Location { get; set; }
            public abstract void RingIsFoundEventHandle(object sender, RingIsFoundEventArgs e);
        }
        public class RingIsFoundEventArgs : EventArgs
        {
            public RingIsFoundEventArgs(string s)
            { Message = s; }
            public string Message { get; set; }
        }
        public class Wizard : Creature
        {
            public override string Name { get; set; }
            public override string Location { get; set; }
            public delegate void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e);
            public override void RingIsFoundEventHandle(object sender, RingIsFoundEventArgs e) { }
            public event RingIsFoundEventHandler RaiseRingIsFoundEvent;
            public Wizard(string name, string location)
            {
                Name = name;
                Location = location;
            }
            public void SomeThisIsChangedInTheAir()
            {
                Console.WriteLine($"{Name} >> Кольцо найдено у старого Бильбо! Призываю вас в Ривендейл!");
                RaiseRingIsFoundEvent?.Invoke(this, new("Ривендейл"));
            }
        }
        public class Hobbit : Creature
        {
            public override string Name { get; set; }
            public override string Location { get; set; }
            public Hobbit(string name, string location)
            {
                Name = name;
                Location = location;
            }
            public override void RingIsFoundEventHandle(object sender, RingIsFoundEventArgs e)
            {
                Console.WriteLine($"{Name} >> Текущее местоположение: {Location}. Покидаю {Location}! Иду в {e.Message}");
                Location = e.Message;
            }
        }
        public class Human : Creature
        {
            public override string Name { get; set; }
            public override string Location { get; set; }
            public Human(string name, string location)
            {
                Name = name;
                Location = location;
            }
            public override void RingIsFoundEventHandle(object sender, RingIsFoundEventArgs e)
            {
                Console.WriteLine($"{Name} >> Текущее местоположение: {Location}. " +
                                  $"Волшебник {((Wizard)(sender)).Name} позвал. Моя цель {e.Message}");
                Location = e.Message;
            }
        }

        public class Elf : Creature
        {
            public override string Name { get; set; }
            public override string Location { get; set; }
            public Elf(string name, string location)
            {
                Name = name;
                Location = location;
            }
            public override void RingIsFoundEventHandle(object sender, RingIsFoundEventArgs e)
            {
                Console.WriteLine(
                    $"{Name} >> Текущее местоположение: {Location}. Звезды светят не так ярко как обычно. " +
                    $"Цветы увядают. Листья предсказывают идти в {e.Message}");
                Location = e.Message;
            }
        }

        public class Dwarf : Creature
        {
            public override string Name { get; set; }
            public override string Location { get; set; }
            public Dwarf(string name, string location)
            {
                Name = name;
                Location = location;
            }
            public override void RingIsFoundEventHandle(object sender, RingIsFoundEventArgs e)
            {
                Console.WriteLine($"{Name} >> Текущее местоположение: {Location}. " +
                                  $"Точим топоры, собираем припасы! Выдвигаемся в {e.Message}");
                Location = e.Message;
            }
        }
        static void Main(string[] args)
        {
            Wizard wizard = new("Гендальф", "Валимар");
            Creature[] creatures = { new Hobbit("Фродо", "Менегрот"), new Hobbit("Сэм", "Утумно"), new Hobbit("Пэпин", "Андуниэ"),
                new Hobbit("Мэрри", "Ниндамос"), new Human("Боромир", "Тирион"), new Human("Арагорн", "Ондосто"),
                new Dwarf("Гимли", "Изенгард"), new Elf("Леголас", "Аннуминас") };
            foreach (var creature in creatures)
            {
                wizard.RaiseRingIsFoundEvent += creature.RingIsFoundEventHandle;
            }
            wizard.SomeThisIsChangedInTheAir();
        }
    }
}
