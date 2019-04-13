using LabyrinthApp;
using NUnit.Framework;
using System;

namespace CellTests {
    class CellTests {
        [Test]
        public void WrongCellEnum() {
            Assert.AreEqual(10, (int)TypeOfCell.greatWall);
            Assert.AreEqual(1, (int)TypeOfCell.ground);
            Assert.AreEqual(0, (int)TypeOfCell.wall);
            Assert.AreEqual(2, (int)TypeOfCell.coin);
        }
    }
}
