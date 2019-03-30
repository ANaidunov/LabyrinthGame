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
                        if (hero.Y - 1 > 0 && lab[hero.X, hero.Y - 1].Val != (byte)TypeOfCell.wall && lab[hero.X, hero.Y - 1].Val != (byte)TypeOfCell.wall)
                            hero.Y--;
                        else if (lab[hero.X, hero.Y - 1].Val == (byte)TypeOfCell.wall) {
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
                        if (hero.X + 1 > 0 && lab[hero.X + 1, hero.Y].Val != (byte)TypeOfCell.wall && lab[hero.X + 1, hero.Y].Val != (byte)TypeOfCell.greatWall)
                            hero.X++;
                        else if (lab[hero.X + 1, hero.Y].Val == (byte)TypeOfCell.wall) {
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
                        if (hero.Y + 1 > 0 && lab[hero.X, hero.Y + 1].Val != (byte)TypeOfCell.wall && lab[hero.X, hero.Y + 1].Val != (byte)TypeOfCell.greatWall)
                            hero.Y++;
                        else if (lab[hero.X, hero.Y + 1].Val == (byte)TypeOfCell.wall) {
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
                        if (hero.Y > 0 && lab[hero.X - 1, hero.Y].Val != (byte)TypeOfCell.wall && lab[hero.X - 1, hero.Y].Val != (byte)TypeOfCell.greatWall)
                            hero.X--;
                        else if (lab[hero.X, hero.Y + 1].Val == (byte)TypeOfCell.wall) {
                            Console.WriteLine("Hero cant walk through walls of labyrinth");
                            Thread.Sleep(100);
                        }
                        else {
                            Console.WriteLine("Hero came out from borders of labyrinth");
                            Thread.Sleep(100);
                        }
                        break;
                    }

            }
            if (lab[hero.X, hero.Y].Val == (byte)TypeOfCell.coin) {   // check pos of hero for coin
                hero.AddCoin();
                lab.RemoveCoin(hero.X, hero.Y);
            }
        }
    }
}
