using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthApp {
    public static class Drawer {
        public static void DrawLabyrinth(Labyrinth labyrinth, Hero hero) {
            Console.Clear();
            for (int y = 0; y < labyrinth.Height; y++) {
                for (int x = 0; x < labyrinth.Width; x++) {
                    if (labyrinth[x, y].X == hero.X && labyrinth[x, y].Y == hero.Y)
                        Console.Write(hero.Symbol);
                    else if (labyrinth[x, y].Val == 10) // great wall :)
                        Console.Write('#');
                    else if (labyrinth[x, y].Val == 0) // wall
                        Console.Write('#');
                    else if (labyrinth[x, y].Val == 2) // coin
                        Console.Write('o');
                    else  // pass
                        Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Count of coins: {hero.CoinsCount}");
        }

        public static void DrawLabyrinth(Labyrinth labyrinth) {
            Console.Clear();
            for (int y = 0; y < labyrinth.Height; y++) {
                for (int x = 0; x < labyrinth.Width; x++) {
                    if (labyrinth[x, y].Val == 10) // great wall :)
                        Console.Write('#');
                    else if (labyrinth[x, y].Val == 0) // wall
                        Console.Write('#');
                    else if (labyrinth[x, y].Val == 2) // coin
                        Console.Write('o');
                    else  // pass
                        Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}
