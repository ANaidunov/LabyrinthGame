namespace LabyrinthApp.LabyrinthParts {
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
        Coin = 2, //coin 2
        Wall = 0, //wall 0
        GreatWall = 10, //greatWall 10
        Ground = 1 //ground 1
    }
}