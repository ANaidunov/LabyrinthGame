using System;
using LabyrinthCore.LabyrinthParts;

namespace LabyrinthCore.SingletonHero {
    internal interface IHeroMotions {
        bool Motion(ConsoleKeyInfo key, ILabyrinth lab);
    }
}