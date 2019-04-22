using System.Collections.Generic;
using LabyrinthApp.SingletonHero;

namespace LabyrinthApp.LabyrinthParts {
    public interface ILabyrinth {
        void GetCoinsCount();
        void SpawnHero(IHero hero);
        void RemoveCoin(int x, int y);
        Cell this[int x, int y] { get; set; }
        int GetWidth();
        int GetHeight();
        void CheckCoin(int x, int y);

        int Width { get; }
        int Height { get; }
        List<Cell> Cells { get; set; }
        int CoinsCount { get; set; }
        int StartCoinsCount { get; set; }
    }
}