using LabyrinthApp;
using LabyrinthCore.SingletonHero;
using NUnit.Framework;
using System;

namespace LabyrinthApp.Test.SingletonHero {
    public class SingletonHeroTests {
        [SetUp]
        public void Setup() {
            hero = Hero.GetHero;
        }

        public Hero hero { get; set; }

        [Test]
        public void HeroStartCoinsCountIs0() {
            //arrange
            var actual = hero.CoinsCount;
            var expected = 0;
            //act

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AreHeroSingle() {
            //arrange
            var hero1 = Hero.GetHero;

            //act

            //assert
            Assert.AreSame(hero, hero1);
        }

        [Test]
        public void AddCoinTest() {
            //arrange
            var expected = 1;

            //act
            hero.AddCoin();
            var actual = hero.CoinsCount;
            hero.CoinsCount--; //because hero is singleton, and I cant reset his properties, but i can undo changes

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}