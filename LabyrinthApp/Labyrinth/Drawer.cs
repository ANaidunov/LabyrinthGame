using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthApp {
    public static class Drawer {
        public static void DrawLabyrinth(Labyrinth labyrinth, Hero hero) {
            var oldColor = Console.ForegroundColor;
            var sb = new StringBuilder();
            Console.Clear();
            for (int y = 0; y < labyrinth.Height; y++) {
                for (int x = 0; x < labyrinth.Width; x++) {
                    if (labyrinth[x, y].X == hero.X && labyrinth[x, y].Y == hero.Y) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        // sb.Append(hero.Symbol);
                        Console.Write(hero.Symbol);
                        Console.ForegroundColor = oldColor;
                    }
                    else if (labyrinth[x, y].Val == 10 || labyrinth[x, y].Val == 0) { // great wall or wall
                        //var oldColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        //sb.Append('#');
                        Console.Write('#');
                        Console.ForegroundColor = oldColor;
                    }
                    else if (labyrinth[x, y].Val == 2) { // coin
                                                         //   var oldColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        //sb.Append('o');
                        Console.Write('o');
                        Console.ForegroundColor = oldColor;
                    }
                    else  // pass
                        Console.Write(' ');
                        //sb.Append(' ');
                }
                //  sb.AppendLine();
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            //sb.AppendLine($"Count of coins: {hero.CoinsCount}");
            Console.WriteLine($"Count of coins: {hero.CoinsCount}");
            Console.ForegroundColor = oldColor;
            
        //    Console.Write(sb);
        }

        public static void DrawLabyrinth(Labyrinth labyrinth) {
            Console.Clear();
            var oldColor = Console.ForegroundColor;
            for (int y = 0; y < labyrinth.Height; y++) {
                for (int x = 0; x < labyrinth.Width; x++) {
                    if (labyrinth[x, y].Val == 10 || labyrinth[x, y].Val == 0) { // great wall or wall
                        Console.ForegroundColor = ConsoleColor.Green;
                        // sb.Append('#');
                        Console.Write('#');
                        Console.ForegroundColor = oldColor;
                    }
                    else if (labyrinth[x, y].Val == 2) { // coin
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        //sb.Append('o');
                        Console.Write('o');
                        Console.ForegroundColor = oldColor;
                    }
                    else  // pass
                        Console.Write(' ');
                     //   sb.Append(' ');
                }
                Console.WriteLine();
               // sb.AppendLine();
            }
         //   Console.Write(sb);
        }
    }
}
