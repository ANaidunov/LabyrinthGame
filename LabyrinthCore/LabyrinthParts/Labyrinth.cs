using System;
using System.Collections.Generic;
using System.Linq;
using LabyrinthCore.SingletonHero;

namespace LabyrinthCore.LabyrinthParts {
    public class Labyrinth : ILabyrinth {
        public Labyrinth(int width, int height) {
            Width = width;
            Height = height;
            for (var y = 0; y < Height; y++)
            for (var x = 0; x < Width; x++)
                if (x == 0 || x == Width - 1 || y == 0 || y == Height - 1) {
                    var cell = new Cell(x, y, TypeOfCell.GreatWall); // border made from greatWall blocks
                    Cells.Add(cell);
                }
                else {
                    var cell = new Cell(x, y, TypeOfCell.Wall); // all cells are walls
                    Cells.Add(cell);
                }
        }

        public void GetCoinsCount() {
            var cellsCoin = from cel in Cells
                where cel.Val == TypeOfCell.Coin
                select cel;
            CoinsCount = cellsCoin.Count();
        }


        public void SpawnHero(IHero hero) { // spawn hero only in ground or coin cells 
            var cells = Cells.Where(cell =>
                cell.Val == TypeOfCell.Ground
                || cell.Val == TypeOfCell.Coin);
            var cellsList = cells.ToList();
            var rnd = new Random();
            var randIndex = rnd.Next(cellsList.Count);
            hero.X = cellsList[randIndex].X;
            hero.Y = cellsList[randIndex].Y;
            HeroSpawnFlag = true;
            if (cellsList[randIndex].Val == TypeOfCell.Coin) RemoveCoin(hero.X, hero.Y);
            GetCoinsCount();
            StartCoinsCount = CoinsCount;
        }

        public Cell this[int x, int y] {
            get { return Cells.SingleOrDefault(cell => cell.X == x && cell.Y == y); }

            set {
                var oldCell = this[value.X, value.Y];
                if (oldCell != null) Cells.Remove(oldCell);

                Cells.Add(value);
            }
        }

        public void RemoveCoin(int x, int y) {
            this[x, y].Val = TypeOfCell.Ground; // coin -> pass
        }

        public int GetWidth() => Width;

        public int GetHeight() => Height;

        public void CheckCoin(int x, int y) {
            var hero = Hero.GetHero;
            if (this[x, y].Val != TypeOfCell.Coin) return;
            hero.AddCoin();
            RemoveCoin(x,y);
        }

        public int Width { get; }
        public int Height { get; }
        public List<Cell> Cells { get; set; } = new List<Cell>();
        public int CoinsCount { get; set; }
        public int StartCoinsCount { get; set; }
        public bool HeroSpawnFlag { get; set; } = false;
    }
}