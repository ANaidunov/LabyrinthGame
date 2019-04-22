using System;
using System.IO;
using LabyrinthApp.LabyrinthParts;
using LabyrinthApp.SingletonHero;
using Moq;
using NUnit.Framework;

namespace LabyrinthApp.Test.LabyrinthParts {
    internal class DrawerTests {
        public Mock<ILabyrinth> labMock = new Mock<ILabyrinth>();
        public Mock<IHero> heroMock = new Mock<IHero>();

        [Test]
        public void WriteStatsTest() {
            using (var sw = new StringWriter()) {

                //arrange
                labMock.Setup(x => x.StartCoinsCount).Returns(1);
                heroMock.Setup(x => x.CoinsCount).Returns(0);
                Console.SetOut(sw);
                var expected = "Count of coins: 0 from 1";

                //act
                Drawer.WriteStats(labMock.Object);

                //assert
                Assert.AreEqual(expected, sw.ToString().Trim());
            }
        }

        [Test]
        public void WriteRulesTest() {
            using (var sw = new StringWriter()) {

                //arrange
                Console.SetOut(sw);
                var expected = "Press R to start again\r\nCollect all coins to win!";

                //act
                Drawer.WriteRules();

                //assert
                Assert.AreEqual(expected, sw.ToString().Trim());
            }
        }
    }
}