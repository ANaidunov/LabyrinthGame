using LabyrinthApp;
using NUnit.Framework;
using System;

namespace HeroTests {
    public class HeroTests {
        public void Setup() {
        }

        public Hero hero = Hero.GetHero;

        [Test]
        public void HeroStartCoinsCountIs0() {
            hero = Hero.GetHero;
            Assert.AreEqual(hero.CoinsCount, 0);
        }

        [Test]
        public void HeroWrongCord() {
            var generator = new LabGenerator(5, 5);
            var lab = generator.GetLabyrinth();
            hero.X = 6;
            hero.Y = 5;
            Assert.AreEqual(lab[hero.X, hero.Y], null);
        }

        [Test]
        public void HeroPosIsWall() {
            var generator = new LabGenerator(5, 5);
            var lab = generator.GetLabyrinth();
            hero.X = 0;
            hero.Y = 0;
            Assert.AreEqual(lab[hero.X, hero.Y].Val, TypeOfCell.greatWall);
        }



        [Test]
        public void HeroCollectCoin() {
            var generator = new LabGenerator(3, 4);
            var lab = generator.GetLabyrinth();
            lab[2, 1].Val = TypeOfCell.coin;

            var heroMotions = new HeroMotions();

            var keyInfo = new ConsoleKeyInfo('d', ConsoleKey.D, false, false, false);
            heroMotions.Motion(keyInfo, lab);

            Assert.AreEqual(hero.CoinsCount, 1);
        }

        [Test]
        public void AreHeroSingle() {
            var hero1 = Hero.GetHero;

            Assert.AreSame(hero, hero1);
        }
    }
}