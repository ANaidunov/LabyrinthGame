using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabyrinthApp {
    class Program {
        static void Main(string[] args) {
            var generator = new LabGenerator(21, 15);
            var lab = generator.GetLabyrinth();
            var hero = Hero.GetHero;
            lab.SpawnHero();
            Drawer.DrawLabyrinth(lab, true);
            var heroMotions = new HeroMotions();
            ConsoleKeyInfo key;
            Drawer.WriteRules();
            do {
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.R) {
                    lab = generator.GetLabyrinth();
                    hero.CoinsCount = 0;
                    lab.SpawnHero();
                    Drawer.DrawLabyrinth(lab, true);
                    Drawer.WriteRules();
                }
                else {
                    if (heroMotions.Motion(key, lab)) {
                        Drawer.DrawLabyrinth(lab, true);
                        if (lab.CoinsCount == hero.CoinsCount) {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You Win! Press R to start again, or ESC to exit.");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        Drawer.WriteRules();
                    }
                }
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}
