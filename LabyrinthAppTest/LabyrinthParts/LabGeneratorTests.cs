using System;
using LabyrinthApp.LabyrinthParts;
using NUnit.Framework;

namespace LabyrinthApp.Test.LabyrinthParts {
    class LabGeneratorTests {
        [SetUp]
        public void Setup() {
        }

        [Test]
        [TestCase(3, 3)]
        [TestCase(5, 10)]
        public void LabGeneratorTestWithNormalArgs(int height, int width) {
            //arrange

            //act

            //assert
            Assert.That(() => new LabGenerator(height, width), Throws.Nothing);
        }

        [Test]
        [TestCase(-3,3)]
        [TestCase(1,10)]
        public void LabGeneratorTestWithWrongArgs(int height, int width) {
            //arrange
           
            //act
            
            //assert
            Assert.That(()=> new LabGenerator(height, width), Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void GetLabyrinthTest() {
            //arrange
            var labGenerator = new LabGenerator();
            var lab = labGenerator.GetLabyrinth();
            //act

            //assert
            Assert.IsNotNull(lab);
        }
    }
}
