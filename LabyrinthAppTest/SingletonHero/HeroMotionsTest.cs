using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using LabyrinthApp.SingletonHero;
using Moq;
using LabyrinthApp.LabyrinthParts;

namespace LabyrinthApp.Test.SingletonHero {

    class HeroMotionsTest {

        [SetUp]
        public void SetUp() {
          
        }

        [Test]
        public void MotionsTest() {

            var hero = Hero.GetHero;
            var lab = new Mock<ILabyrinth>();
            var heroMotion = new HeroMotions();
            var expected = true;

            var actual = heroMotion.Motion(new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false), lab.Object);

            Assert.AreEqual(expected, actual);
        }
    }
}
