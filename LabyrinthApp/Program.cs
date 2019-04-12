using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabyrinthApp {
    class Program {
        static void Main(string[] args) {
            var level = 1;
            var size = 2 + level;
            var generator = new LabGenerator(size, size);
            var lab = generator.GetLabyrinth();
            var hero = Hero.GetHero;
            try {
                if (lab == null)
                    throw new ArgumentNullException();
            }
            catch {
                Console.WriteLine("Invalid lab size");
                Console.ReadKey();
                return;
            }
            lab.SpawnHero();
            lab.GetCoinsCount();
            Drawer.DrawLabyrinth(lab, true);
            Drawer.WriteStats(lab);
            var heroMotions = new HeroMotions();
            ConsoleKeyInfo key;
            Drawer.WriteRules();
            bool win = false;
            do {
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.R) {
                    if (win) {
                        level++;
                        size += 2;
                    }
                    win = false;
                    generator = new LabGenerator(size, size);
                    lab = generator.GetLabyrinth();
                    hero.CoinsCount = 0;
                    lab.SpawnHero();
                    lab.GetCoinsCount();
                    Drawer.DrawLabyrinth(lab, true);
                    Drawer.WriteStats(lab);
                    Drawer.WriteRules();
                }
                else if(!win) {
                    var didHeroMove = heroMotions.Motion(key, lab);
                    if (didHeroMove) {
                        Drawer.DrawLabyrinth(lab, true);
                        Drawer.WriteRules();
                        Drawer.WriteStats(lab);
                    }
                    if (lab.CoinsCount == hero.CoinsCount) {
                        win = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You Win! Press R to start next level, or ESC to exit.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}
