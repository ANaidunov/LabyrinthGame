using System;
using LabyrinthApp.LabyrinthParts;

namespace LabyrinthApp.SingletonHero {
    public class HeroMotions {

        public Hero hero = Hero.GetHero;

        public bool Motion(ConsoleKeyInfo key, Labyrinth lab) {
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

                
                if (lab[hero.X, hero.Y].Val == TypeOfCell.Coin) {
                    hero.AddCoin();
                    lab.RemoveCoin(hero.X, hero.Y);
                }

                return motionFlag;
            }
        }

        public void Up(Labyrinth lab) {
            if (hero.Y - 1 > 0 && lab[hero.X, hero.Y - 1].Val != TypeOfCell.Wall
                               && lab[hero.X, hero.Y - 1].Val != TypeOfCell.GreatWall)
                hero.Y--;
        
    }

        public void Down(Labyrinth lab) {
            if (hero.Y + 1 < lab.Height && lab[hero.X, hero.Y + 1].Val != TypeOfCell.Wall
                               && lab[hero.X, hero.Y + 1].Val != TypeOfCell.GreatWall)
                hero.Y++;
        }

        public void Left(Labyrinth lab) {
            if (hero.X - 1 > 0 && lab[hero.X - 1, hero.Y].Val != TypeOfCell.Wall
                           && lab[hero.X - 1, hero.Y].Val != TypeOfCell.GreatWall)
                hero.X--;
        }

        public void Right(Labyrinth lab) {
            if (hero.X + 1 < lab.Width && lab[hero.X + 1, hero.Y].Val != TypeOfCell.Wall
                               && lab[hero.X + 1, hero.Y].Val != TypeOfCell.GreatWall)
                hero.X++;
        }
    }
}