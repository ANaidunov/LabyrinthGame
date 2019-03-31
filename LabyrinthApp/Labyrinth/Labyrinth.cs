﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthApp {
    public class Labyrinth {
        public Labyrinth(int _width, int _heigth) {
            Width = _width;
            Height = _heigth;
            for (int y = 0; y < Height; y++) {
                for (int x = 0; x < Width; x++) {
                    if (x == 0 || x == Width - 1 || y == 0 || y == Height - 1) {
                        var cell = new Cell(x, y, TypeOfCell.greatWall); // border maked from greatWall blocks
                        Cells.Add(cell);
                    }
                    else {
                        var cell = new Cell(x, y, TypeOfCell.wall); // all cells are walls
                        Cells.Add(cell);
                    }
                }
            }
        }

        public void SpawnHero() {  // spawn hero only in ground cells
            var hero = Hero.GetHero;
            var cells = from cel in this.Cells
                        where cel.Val == TypeOfCell.ground
                        select cel;
            var cellsList = cells.ToList();
            Random rnd = new Random();
            var randIdnex = rnd.Next(cellsList.Count);
            hero.X = cellsList[randIdnex].X;
            hero.Y = cellsList[randIdnex].Y;
        }

        public Cell this[int x, int y] {
            get {
                return Cells.SingleOrDefault(cell => cell.X == x && cell.Y == y);
            }

            set {
                var oldCell = this[value.X, value.Y];
                if (oldCell != null) {
                    Cells.Remove(oldCell);
                }

                Cells.Add(value);
            }
        }

        public void RemoveCoin(int x, int y) {
            this[x, y].Val = TypeOfCell.ground; // coin -> pass
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
        public List<Cell> Cells { get; set; } = new List<Cell>();
    }
}
