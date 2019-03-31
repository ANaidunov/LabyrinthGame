using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthApp {
    public class Cell {
        public Cell(int x, int y, TypeOfCell typeOfCell) {
            X = x;
            Y = y;
            Val = typeOfCell;
        }

        public int X { get; }
        public int Y { get; }
        public TypeOfCell Val { get; set; }
    }
    
    public enum TypeOfCell {
        coin = 2,
        wall = 0,
        greatWall = 10,
        ground = 1
    }
    
}
