using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabyrinthApp {
    public class LabGenerator {
        private Labyrinth _lab;
        private List<Cell> _blueCells = new List<Cell>();
        private List<Cell> _orangeCells = new List<Cell>();
        private int Width { get; set; }
        private int Height { get; set; }

        private Random rnd = new Random();

        /// <summary>
        /// Use default width == 3 and height == 6
        /// </summary>
        public LabGenerator() : this(3, 6) {

        }

        /// <summary>
        /// You can pass custom width and height
        /// </summary>
        /// <param name="width">width of labirinth</param>
        /// <param name="height">height of labirinth</param>
        public LabGenerator(int width, int height) {
            Width = width;
            Height = height;
        }

        public Labyrinth GetLabirinth() {
            _lab = new Labyrinth(Width, Height);

            for (int x = 1; x < _lab.Width - 1; x += 2) {
                for (int y = 1; y < _lab.Height - 1; y += 2) {
                    _blueCells.Add(_lab[x, y]);
                }
            }
   
            Step(GetRandomCell(_blueCells), _lab);
            return _lab;
        }

        private void Step(Cell currentCell, Labyrinth lab) {
           
            currentCell.Val = (byte)rnd.Next(1, 3);    //rnd 1 or 2 (zero or coin)
            var neighbourCells = GetNeighbourCells(currentCell, lab);
            if (neighbourCells[0] != null || neighbourCells[1] != null || neighbourCells[2] != null || neighbourCells[3] != null) {
                var randIdnex = rnd.Next(neighbourCells.Count);
                var nextCell = neighbourCells[randIdnex];

                while (neighbourCells[randIdnex] == null) {
                    randIdnex = rnd.Next(neighbourCells.Count);
                    nextCell = neighbourCells[randIdnex];
                }

                switch (randIdnex) {
                    case 0: // left
                        lab[currentCell.X - 1, currentCell.Y].Val = (byte)rnd.Next(1, 3);
                        break;
                    case 1: // right
                        lab[currentCell.X + 1, currentCell.Y].Val = (byte)rnd.Next(1, 3);
                        break;
                    case 2: // up 
                        lab[currentCell.X, currentCell.Y - 1].Val = (byte)rnd.Next(1, 3);
                        break;
                    case 3: // down
                        lab[currentCell.X, currentCell.Y + 1].Val = (byte)rnd.Next(1, 3);
                        break;

                }
                //currentCell.Val = (byte)rnd.Next(1,2);    //rnd 1 or 2 (zero or coin)
                _blueCells.Remove(nextCell);
                _orangeCells.Add(nextCell);

                Step(nextCell, lab);
            }
            //if there are no neighbour walls
            else if (_orangeCells.Any()) {
                var nextCell = _orangeCells.Last();
                _orangeCells.Remove(nextCell);
                Step(nextCell, lab);
            }
            return;
        }

        private List<Cell> GetNeighbourCells(Cell cell, Labyrinth lab) {
            List<Cell> BlueNeighbours = new List<Cell>();
            if (cell.X - 2 >= 1 && !IsVisited(lab[cell.X - 2, cell.Y], lab)) {  // left
                BlueNeighbours.Add(lab[cell.X - 2, cell.Y]);
            }
            else
                BlueNeighbours.Add(null);
            if (cell.X + 2 < lab.Width - 1 && !IsVisited(lab[cell.X + 2, cell.Y], lab)) {  // right
                BlueNeighbours.Add(lab[cell.X + 2, cell.Y]);
            }
            else
                BlueNeighbours.Add(null);
            if (cell.Y - 2 >= 1 && !IsVisited(lab[cell.X, cell.Y - 2], lab)) {  // up
                BlueNeighbours.Add(lab[cell.X, cell.Y - 2]);
            }
            else
                BlueNeighbours.Add(null);
            if (cell.Y + 2 < lab.Height - 1 && !IsVisited(lab[cell.X, cell.Y + 2], lab)) {  // down
                BlueNeighbours.Add(lab[cell.X, cell.Y + 2]);
            }
            else
                BlueNeighbours.Add(null);
            return BlueNeighbours;
        }

        private bool IsVisited(Cell cell, Labyrinth lab) {
            if (cell == null) return true;
            if (lab[cell.X - 1, cell.Y] != null && cell.X - 1 >= 0 && lab[cell.X - 1, cell.Y].Val != 0 && lab[cell.X - 1, cell.Y].Val != 10) {
                return true;
            }
            if (lab[cell.X + 1, cell.Y] != null && cell.X + 1 <= lab.Width - 1 && lab[cell.X + 1, cell.Y].Val != 0 && lab[cell.X + 1, cell.Y].Val != 10) {
                return true;
            }
            if (lab[cell.X, cell.Y - 1] != null && cell.Y - 1 >= 0 && lab[cell.X, cell.Y - 1].Val != 0 && lab[cell.X, cell.Y - 1].Val != 10) {
                return true;
            }
            if (lab[cell.X, cell.Y + 1] != null && cell.X + 1 <= lab.Width - 1 && lab[cell.X, cell.Y + 1].Val != 0 && lab[cell.X, cell.Y + 1].Val != 10) {
                return true;
            }
            return false;
        }

        private Cell GetRandomCell(List<Cell> cells) {
            Random rnd = new Random();
            var randIdnex = rnd.Next(cells.Count);
            return cells[randIdnex];
        }
    }
}