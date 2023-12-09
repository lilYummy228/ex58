using System;
using System.Collections.Generic;
using System.Linq;

namespace ex58
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MilitaryBase militaryBase = new MilitaryBase();

            militaryBase.ShowAllTroops();

            militaryBase.OverrideTroops();

            militaryBase.ShowAllTroops();
        }
    }

    class MilitaryBase
    {
        private List<Soldier> _firstTroop = new List<Soldier>();
        private List<Soldier> _secondTroop = new List<Soldier>();

        public MilitaryBase()
        {
            AddSoldiers();
        }

        public void OverrideTroops()
        {
            var overridedTroop = _firstTroop.Where(soldier => soldier.LastName.StartsWith("Б")).ToList();
            _firstTroop = _firstTroop.Except(overridedTroop).ToList();
            _secondTroop = _secondTroop.Union(overridedTroop).ToList();
        }

        public void ShowAllTroops()
        {
            ShowTroop(_firstTroop, 1);

            ShowTroop(_secondTroop, 2);
        }

        private void ShowTroop(List<Soldier> troop, int number)
        {
            Console.WriteLine($"Солдаты {number} отряда: ");

            foreach (Soldier soldier in troop)
            {
                soldier.ShowInfo();
            }

            Console.WriteLine();
        }

        private void AddSoldiers()
        {
            _firstTroop.Add(new Soldier("Илья", "Богатырев"));
            _firstTroop.Add(new Soldier("Евгений", "Морозов"));
            _firstTroop.Add(new Soldier("Дмитрий", "Нагиев"));
            _firstTroop.Add(new Soldier("Глеб", "Бурунов"));
            _firstTroop.Add(new Soldier("Олег", "Шакиров"));
            _secondTroop.Add(new Soldier("Василий", "Ларионов"));
            _secondTroop.Add(new Soldier("Егор", "Голосков"));
            _secondTroop.Add(new Soldier("Михаил", "Дружнов"));
            _secondTroop.Add(new Soldier("Георгий", "Побеносцев"));
            _secondTroop.Add(new Soldier("Роман", "Харьков"));
        }
    }

    class Soldier
    {
        public Soldier(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{LastName} {Name}");
        }
    }
}
