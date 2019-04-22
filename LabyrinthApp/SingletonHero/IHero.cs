﻿using System.Collections.Generic;

namespace LabyrinthApp.SingletonHero {
    public interface IHero {
        int X { get; set; }
        int Y { get; set; }
        char Symbol { get; set; }
        int CoinsCount { get; set; }

        void AddCoin();
    }
}