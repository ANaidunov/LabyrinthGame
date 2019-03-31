using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabyrinthApp {
    class Program {
        static void Main(string[] args) {
            var generator = new LabGenerator(21, 13);
            var lab = generator.GetLabyrinth();
            var hero = Hero.GetHero;
            lab.SpawnHero();
            Drawer.DrawLabyrinth(lab, true);
            var heroMotions = new HeroMotions();
            ConsoleKeyInfo key;
            do {
                Console.WriteLine($"Press R to start again");
                key = Console.ReadKey();
                heroMotions.Motion(key, lab);
                if(key.Key == ConsoleKey.R) {
                    lab = generator.GetLabyrinth();
                    hero.CoinsCount = 0;
                    lab.SpawnHero();
                }
                Drawer.DrawLabyrinth(lab, true);
            } while (key.Key != ConsoleKey.Escape);
            Console.ReadKey();
        }
    }
}
