﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabyrinthApp {
    class Program {
        static void Main(string[] args) {
            var generator = new LabGenerator(40, 21);
            var lab = generator.GetLabirinth();
            Console.WriteLine($"Press R to start again");
            var hero = Hero.GetHero;
            Drawer.DrawLabyrinth(lab, hero);
            var heroMotions = new HeroMotions();
            ConsoleKeyInfo key;
            do {
                key = Console.ReadKey();
                heroMotions.Motion(key, lab, hero, generator);
                if (lab[hero.X, hero.Y].Val == (byte)TypeOfCell.coin) {
                    hero.AddCoin();
                    lab.RemoveCoin(hero.X, hero.Y);
                }
                Drawer.DrawLabyrinth(lab, hero);
            } while (key.Key != ConsoleKey.Escape);

            Console.ReadKey();
        }
    }
}
