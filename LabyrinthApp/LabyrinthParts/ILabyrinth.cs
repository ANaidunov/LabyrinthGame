namespace LabyrinthApp.LabyrinthParts {
    public interface ILabyrinth {
        void GetCoinsCount();
        void SpawnHero();
        void RemoveCoin(int x, int y);
    }
}