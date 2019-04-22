using System;
using System.Linq;
using LabyrinthApp.LabyrinthParts;
using LabyrinthApp.SingletonHero;
using Moq;
using NUnit.Framework;

namespace LabyrinthApp.Test.LabyrinthParts {
    public class LabTests {

        public LabGenerator labGen { get; set; }
        public Labyrinth lab { get; set; }

        [SetUp]
        public void SetUp() {
            labGen = new LabGenerator(3, 3);
            lab = labGen.GetLabyrinth();
        }

        [Test]
        public void GetCoinsCountTest() {

            //arrange
            var coins = from cel in lab.Cells
                where cel.Val == TypeOfCell.Coin
                select cel;
            var expectedCoinsCount = coins.Count();

            //act
            lab.GetCoinsCount();
            var actualCoinsCount = lab.CoinsCount;

            //assert
            Assert.AreEqual(expectedCoinsCount, actualCoinsCount);
        }
        
        [Test]
        public void SpawnHeroTest() {

            //arrange
            var heroMock = new Mock<IHero>();
            heroMock.Setup(x => x.X).Returns(1);
            //act
            lab.SpawnHero(heroMock.Object);

            //assert
            Assert.IsTrue(lab.HeroSpawnFlag);
        }

        [Test]
        public void RemoveCoinTest() {

            //arrange
            lab[1, 1].Val = TypeOfCell.Coin;
            lab.GetCoinsCount();
            var excepted = lab.CoinsCount - 1;

            //act
            lab.RemoveCoin(1, 1);
            lab.GetCoinsCount();
            var actual = lab.CoinsCount;

            //assert
            Assert.AreEqual(excepted, actual);
        }
        
        /*[Test]
        public void LabWasUpdate() {
            //arrange
            var labBefore = lab;

            //act
            var newLab = labGen.GetLabyrinth();

            //assert
            Assert.AreNotEqual(labBefore, newLab);
        }*/
    }
}
