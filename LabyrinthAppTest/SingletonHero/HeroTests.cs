using LabyrinthApp;
using LabyrinthApp.SingletonHero;
using NUnit.Framework;
using System;

namespace LabyrinthApp.Test.SingletoneHero {
    public class SingletoneHeroTests {
        [SetUp]
        public void Setup()
        {
        }

        public Hero hero = Hero.GetHero;

        [Test]
        public void HeroStartCoinsCountIs0() {
            var actual = hero.CoinsCount;
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AreHeroSingle() {
            var hero1 = Hero.GetHero;

            Assert.AreSame(hero, hero1);
        }

        [Test]
        public void AddCoinTest() {
            //arrange
            var expected = 1;
            //act
            hero.AddCoin();
            var actual = hero.CoinsCount;
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}