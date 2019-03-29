using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthApp {
    public class Cell {
        public Cell(int x, int y, byte typeOfCell) {
            X = x;
            Y = y;
            Val = typeOfCell;
        }

        public int X { get; }
        public int Y { get; }
        private byte val;
        // Vol 0 - wall, 1 - cell without coin, 2 - cell with coin 
        public byte Val {
            get {
                return val;
            }
            set {
                if (value >= 0 && value <= 2 || value == 10) {
                    val = value;
                }
            }
        }
    }
}
