using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// stringBuilder is commented
namespace LabyrinthApp {
    public static class Drawer {
        public static void DrawLabyrinth(Labyrinth labyrinth, bool drawHero) {
            var oldColor = Console.ForegroundColor;
            var sb = new StringBuilder();
            Console.Clear();
            var hero = Hero.GetHero;
            for (int y = 0; y < labyrinth.Height; y++) {
                for (int x = 0; x < labyrinth.Width; x++) {
                    if (drawHero && labyrinth[x, y].X == hero.X && labyrinth[x, y].Y == hero.Y) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        //sb.Append(hero.Symbol);
                        Console.Write(hero.Symbol);
                        Console.ForegroundColor = oldColor;
                    }
                    else if (labyrinth[x, y].Val == TypeOfCell.greatWall || labyrinth[x, y].Val == TypeOfCell.wall) { // great wall or wall
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        //sb.Append('#');
                        Console.Write('#');
                        Console.ForegroundColor = oldColor;
                    }
                    else if (labyrinth[x, y].Val == TypeOfCell.coin) { // coin
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        //sb.Append('o');
                        Console.Write('o');
                        Console.ForegroundColor = oldColor;
                    }
                    else  // pass
                        Console.Write(' ');
                    // sb.Append(' ');
                }
                //sb.AppendLine();
                Console.WriteLine();
            }
            //Console.Write(sb);
        }

        public static void WriteStats(Labyrinth labyrinth) {
            var hero = Hero.GetHero;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Count of coins: {hero.CoinsCount} from {labyrinth.CoinsCount}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        
        public static void WriteRules() {
            Console.WriteLine($"Press R to start again");
            Console.WriteLine($"Collect all coins to win!");
        }
    }
}
