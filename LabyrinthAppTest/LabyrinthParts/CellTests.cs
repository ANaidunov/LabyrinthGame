using LabyrinthApp.LabyrinthParts;
using NUnit.Framework;

namespace LabyrinthApp.Test.LabyrinthParts {
    class CellTests {
        [Test]
        [TestCase(TypeOfCell.Coin, 2)]
        [TestCase(TypeOfCell.Ground, 1)]
        [TestCase(TypeOfCell.Wall, 0)]
        [TestCase(TypeOfCell.GreatWall, 10)]
        public void WrongCellEnum(TypeOfCell type, int num) {
            //arrange

            //act

            //assert
            Assert.AreEqual(num, (int)type);
        }
    }
}
