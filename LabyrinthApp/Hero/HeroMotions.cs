using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabyrinthApp {
    public class HeroMotions {
        public bool Motion(ConsoleKeyInfo key, Labyrinth lab) {
            var hero = Hero.GetHero;
            {
                bool motionFlag = false;
                switch (key.Key) {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow: {
                            if (hero.Y - 1 > 0 && lab[hero.X, hero.Y - 1].Val != TypeOfCell.wall
                                && lab[hero.X, hero.Y - 1].Val != TypeOfCell.greatWall) {
                                hero.Y--;
                                motionFlag = true;
                            }
                            break;
                        }
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow: {
                            if (hero.X + 1 > 0 && lab[hero.X + 1, hero.Y].Val != TypeOfCell.wall
                                && lab[hero.X + 1, hero.Y].Val != TypeOfCell.greatWall) {
                                hero.X++;
                                motionFlag = true;
                            }
                            break;
                        }
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow: {
                            if (hero.Y + 1 > 0 && lab[hero.X, hero.Y + 1].Val != TypeOfCell.wall
                                && lab[hero.X, hero.Y + 1].Val != TypeOfCell.greatWall) { 
                                hero.Y++;
                                motionFlag = true;
                            }
                            break;
                        }
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow: {
                            if (hero.Y > 0 && lab[hero.X - 1, hero.Y].Val != TypeOfCell.wall
                                && lab[hero.X - 1, hero.Y].Val != TypeOfCell.greatWall) { 
                                hero.X--;
                                motionFlag = true;
                            }
                            break;
                        }
                }
                if (lab[hero.X, hero.Y].Val == TypeOfCell.coin) {   // check pos of hero for coin
                    hero.AddCoin();
                    lab.RemoveCoin(hero.X, hero.Y);
                }
                return motionFlag;
            }
        }
    }


}
