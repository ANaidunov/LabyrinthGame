using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabyrinthApp {
    class Program {
        static void Main(string[] args) {
            var generator = new LabGenerator(13, 13);
            var lab = generator.GetLabirinth();
            Drawer.DrawLabyrinth(lab);
            Console.WriteLine($"Press R to start again");
            var hero = Hero.GetHero;
            Drawer.DrawLabyrinth(lab, hero);
            ConsoleKeyInfo key;
            do {
                key = Console.ReadKey();

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
                            break;
                        }
                }
                if (lab[hero.X, hero.Y].Val == 2) {
                    hero.AddCoin();
                    lab.RemoveCoin(hero.X, hero.Y);
                }
                Drawer.DrawLabyrinth(lab, hero);
            } while (key.Key != ConsoleKey.Escape);

            Console.ReadKey();
        }
    }
}
