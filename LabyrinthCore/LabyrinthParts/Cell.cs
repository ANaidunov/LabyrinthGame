namespace LabyrinthCore.LabyrinthParts {
    public class Cell {
        public Cell(int x, int y, CellType cellType) {
            X = x;
            Y = y;
            Val = cellType;
        }

        public int X { get; }
        public int Y { get; }
        public CellType Val { get; set; }
    }
}