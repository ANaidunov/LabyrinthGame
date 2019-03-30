﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabyrinthApp {
    class Program {
        static void Main(string[] args) {
            var generator = new LabGenerator(20, 13);
            var lab = generator.GetLabirinth();
            var hero = Hero.GetHero;
            Drawer.DrawLabyrinth(lab, hero);
            var heroMotions = new HeroMotions();
            ConsoleKeyInfo key;
            do {
                Console.WriteLine($"Press R to start again");
                key = Console.ReadKey();
                heroMotions.Motion(key, lab, hero, generator);
                if(key.Key == ConsoleKey.R) {
                    lab = generator.GetLabirinth();
                    hero.CoinsCount = 0;
                }
                Drawer.DrawLabyrinth(lab, hero);
            } while (key.Key != ConsoleKey.Escape);
            Console.ReadKey();
        }
    }
}
