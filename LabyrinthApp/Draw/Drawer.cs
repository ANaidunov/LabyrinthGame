using LabyrinthCore.LabyrinthParts;
using LabyrinthCore.SingletonHero;
using System;

// stringBuilder is commented
namespace LabyrinthApp.Draw{
    public static class Drawer {
        public static void DrawLabyrinth(Labyrinth labyrinth, bool drawHero) {
            var oldColor = Console.ForegroundColor;

            // var sb = new StringBuilder();
            Console.Clear();
            var hero = Hero.GetHero;

            for (var y = 0; y < labyrinth.Height; y++) {
                for (var x = 0; x < labyrinth.Width; x++)
                    if (drawHero && labyrinth[x, y].X == hero.X && labyrinth[x, y].Y == hero.Y) {
                        Console.ForegroundColor = ConsoleColor.Green;

                        //sb.Append(hero.Symbol);
                        Console.Write(hero.Symbol);
                        Console.ForegroundColor = oldColor;
                    }
                    else if (labyrinth[x, y].Val == CellType.GreatWall || labyrinth[x, y].Val == CellType.Wall) {
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        //sb.Append('#');
                        Console.Write('#');
                        Console.ForegroundColor = oldColor;
                    }
                    else if (labyrinth[x, y].Val == CellType.Coin) { // coin
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        //sb.Append('o');
                        Console.Write('o');
                        Console.ForegroundColor = oldColor;
                    }
                    else // pass
                    {
                        Console.Write(' ');
                    }

                // sb.Append(' ');
                //sb.AppendLine();
                Console.WriteLine();
            }

            //Console.Write(sb);
        }

        public static void WriteStats(ILabyrinth labyrinth) {
            var hero = Hero.GetHero;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Count of coins: {hero.CoinsCount} from {labyrinth.StartCoinsCount}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void WriteRules() {
            Console.WriteLine("Press R to start again");
            Console.WriteLine("Collect all coins to win!");
        }
    }
}