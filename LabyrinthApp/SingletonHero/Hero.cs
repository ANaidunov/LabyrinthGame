using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace LabyrinthApp.SingletonHero {
    public class Hero : IHero {

        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public char Symbol { get; set; } = '@';
        public int CoinsCount { get; set; }


        public void AddCoin() {
            CoinsCount++;
        }

        private static Hero _hero;

        public static Hero GetHero {
            get {
                if (_hero == null) _hero = new Hero();
                return _hero;
            }
        }

        private Hero() { }
    }
}