using System;
using LabyrinthCore.LabyrinthParts;

namespace LabyrinthCore.SingletonHero {
    public class HeroMotions {

        public Hero hero = Hero.GetHero;

        public bool Motion(ConsoleKeyInfo key, ILabyrinth lab) {
            {
                var motionFlag = true;
                switch (key.Key) {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow: {
                        Up(lab);
                        break;
                    }
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow: {
                        Right(lab);
                        break;
                    }
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow: {
                        Down(lab);
                        break;
                    }
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow: {
                        Left(lab);
                        break;
                    }
                    default: {
                        motionFlag = false;
                        break;
                    }
                }

                lab.CheckCoin(hero.X, hero.Y);

                return motionFlag;
            }
        }

        public void Up(ILabyrinth lab) {
            if (hero.Y - 1 > 0 && lab[hero.X, hero.Y - 1].Val != TypeOfCell.Wall
                               && lab[hero.X, hero.Y - 1].Val != TypeOfCell.GreatWall)
                hero.Y--;
        }

        public void Down(ILabyrinth lab) {
            if (hero.Y + 1 < lab.GetHeight() && lab[hero.X, hero.Y + 1].Val != TypeOfCell.Wall
                               && lab[hero.X, hero.Y + 1].Val != TypeOfCell.GreatWall)
                hero.Y++;
        }

        public void Left(ILabyrinth lab) {
            if (hero.X - 1 > 0 && lab[hero.X - 1, hero.Y].Val != TypeOfCell.Wall
                           && lab[hero.X - 1, hero.Y].Val != TypeOfCell.GreatWall)
                hero.X--;
        }

        public void Right(ILabyrinth lab) {
            if (hero.X + 1 < lab.GetWidth() && lab[hero.X + 1, hero.Y].Val != TypeOfCell.Wall
                               && lab[hero.X + 1, hero.Y].Val != TypeOfCell.GreatWall)
                hero.X++;
        }
    }
}