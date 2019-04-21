using System;
using LabyrinthApp.LabyrinthParts;

namespace LabyrinthApp.SingletonHero {
    internal interface IHeroMotions {
        bool Motion(ConsoleKeyInfo key, ILabyrinth lab);
    }
}