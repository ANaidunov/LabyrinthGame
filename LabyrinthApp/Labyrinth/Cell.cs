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
                val = value;
            }
        }
    }
    
    enum TypeOfCell {
        coin = 2,
        wall = 0,
        greatWall = 10,
        ground = 1
    }
    
}
