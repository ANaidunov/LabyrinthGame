using LabyrinthApp;
using NUnit.Framework;
using System;
using LabyrinthApp.LabyrinthParts;
using System.Linq;
using LabyrinthApp.SingletonHero;

namespace LabyrinthApp.Test.Labyrinth {
    public class LabTests {
        LabGenerator labGen = new LabGenerator(3, 3);

        [Test]
        public void GetCoinsCountTest() {
            //arrange
            var lab = labGen.GetLabyrinth();
            var actualCoinsCount = lab.CoinsCount;

            var coins = from cel in lab.Cells
                        where cel.Val == TypeOfCell.Coin
                        select cel;
            var exceptedCoinsCount = coins.Count();
            //act

            //assert
            Assert.AreEqual(exceptedCoinsCount, actualCoinsCount);
        }

        [Test]
        public void SpawnHeroTest() {
            //arrange
            var lab = labGen.GetLabyrinth();
            var hero = Hero.GetHero;
            var initialX = 0;
            var initialY = 0;
            //act
            lab.SpawnHero();
            var actualX = hero.X;
            var actualY = hero.Y;
            //assert
            Assert.AreNotEqual(initialX, actualX);
            Assert.AreNotEqual(initialY, actualY);
        }

        [Test]
        public void RemoveCoinTest() {
            //arrange
            var lab = labGen.GetLabyrinth();
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


        [Test]
        public void LabWasUpdate() {
            //arrange
            var generator = new LabGenerator(5, 5);
            var labBefore = generator.GetLabyrinth();

            //act
            generator = new LabGenerator(5, 5);
            var newLab = generator.GetLabyrinth();

            //assert
            Assert.AreNotEqual(labBefore, newLab);
        }
    }
}
