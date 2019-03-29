using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabyrinthApp {
    public class HeroMotions {
       public void Motion(ConsoleKeyInfo key, Labyrinth lab, Hero hero, LabGenerator generator) {
            switch (key.Key) {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow: {
                        if (hero.Y - 1 > 0 && lab[hero.X, hero.Y - 1].Val != 0 && lab[hero.X, hero.Y - 1].Val != 10)
                            hero.Y--;
                        else if (lab[hero.X, hero.Y - 1].Val == 0) {
                            Console.WriteLine("Hero cant walk through walls of labyrinth");
                            Thread.Sleep(100);
                        }
                        else {
                            Console.WriteLine("Hero came out from borders of labyrinth");
                            Thread.Sleep(100);
                        }
                        break;
                    }
                case ConsoleKey.D:
                case ConsoleKey.RightArrow: {
                        if (hero.X + 1 > 0 && lab[hero.X + 1, hero.Y].Val != 0 && lab[hero.X + 1, hero.Y].Val != 10)
                            hero.X++;
                        else if (lab[hero.X + 1, hero.Y].Val == 0) {
                            Console.WriteLine("Hero cant walk through walls of labyrinth");
                            Thread.Sleep(100);
                        }
                        else {
                            Console.WriteLine("Hero came out from borders of labyrinth");
                            Thread.Sleep(100);
                        }
                        break;
                    }
                case ConsoleKey.S:
                case ConsoleKey.DownArrow: {
                        if (hero.Y + 1 > 0 && lab[hero.X, hero.Y + 1].Val != 0 && lab[hero.X, hero.Y + 1].Val != 10)
                            hero.Y++;
                        else if (lab[hero.X, hero.Y + 1].Val == 0) {
                            Console.WriteLine("Hero cant walk through walls of labyrinth");
                            Thread.Sleep(300);
                        }
                        else {
                            Console.WriteLine("Hero came out from borders of labyrinth");
                            Thread.Sleep(100);
                        }
                        break;
                    }
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow: {
                        if (hero.Y > 0 && lab[hero.X - 1, hero.Y].Val != 0 && lab[hero.X - 1, hero.Y].Val != 10)
                            hero.X--;
                        else if (lab[hero.X, hero.Y + 1].Val == 0) {
                            Console.WriteLine("Hero cant walk through walls of labyrinth");
                            Thread.Sleep(100);
                        }
                        else {
                            Console.WriteLine("Hero came out from borders of labyrinth");
                            Thread.Sleep(100);
                        }
                        break;
                    }
                case ConsoleKey.R: {
                        lab = generator.GetLabirinth();
                        hero.CoinsCount = 0;
                        break;
                    }
            }
        }
    }
}
