
using LabyrinthCore.LabyrinthParts;
using NUnit.Framework;

namespace LabyrinthApp.Test.LabyrinthParts {
    class CellTests {
        [Test]
        [TestCase(CellType.Coin, 2)]
        [TestCase(CellType.Ground, 1)]
        [TestCase(CellType.Wall, 0)]
        [TestCase(CellType.GreatWall, 10)]
        public void WrongCellEnum(CellType type, int num) {
            //arrange

            //act

            //assert
            Assert.AreEqual(num, (int)type);
        }
    }
}
