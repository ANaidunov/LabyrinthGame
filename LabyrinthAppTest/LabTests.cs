using LabyrinthApp;
using NUnit.Framework;
using System;

namespace LabyrinthTests {
    class LabTests {

        [Test]
        [TestCase(1, -1)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(-1, -1)]
        public void TestGenerateLabWithInvalidArgs(int height, int width) {
            var generator = new LabGenerator(height, width);
            var lab = generator.GetLabyrinth();

            Assert.AreEqual(lab, null);
        }

        [Test]
        public void LabWasUpdate() {
            var generator = new LabGenerator(5, 5);
            var labBefore = generator.GetLabyrinth();

            generator = new LabGenerator(5, 5);
            var newLab = generator.GetLabyrinth();

            Assert.AreNotEqual(labBefore, newLab);
        }
    }
}
