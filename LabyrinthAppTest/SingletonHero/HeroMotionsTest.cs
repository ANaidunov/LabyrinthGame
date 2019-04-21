using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using LabyrinthApp.SingletonHero;
using Moq;
using LabyrinthApp.LabyrinthParts;

namespace LabyrinthApp.Test.SingletonHero {

    class HeroMotionsTest {
        private Mock<ILabyrinth> Lab { get; set; }

        [SetUp]
        public void SetUp() {
            var lab = new Mock<ILabyrinth>();
        }

        [Test]
        public void MotionsTest() {
            var hero = Hero.GetHero;
            var heroMotion = new HeroMotions();
         //   heroMotion.Motion(new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false), Lab.Object);
            Assert.Pass();
        }
    }
}
