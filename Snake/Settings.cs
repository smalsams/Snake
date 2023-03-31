using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    //class, which is used for initialization of the game
    internal class Settings
    {
        public static int Speed; //Speed of the snake
        public static int Level; //Level of the snake(changes after certain amount of food eaten)
        public static int Width; //Width of a single point on the gameboard
        public static int Height; //Height of a single point on the gameboard
        public static Directions Dir; //Stores the current direction
        public static Modes Mode; //Stores the gamemode of current game

        public static bool Walls; //Indicates whether the walls are active or not
        public static int EatenFruit; //Counts the eaten food and is used for calculation of the level
        public static int PathCount;
        public static int AvgPathLength;
        public Settings()
        {
            Speed = 1;
            Level = 1;
            Width = 20;
            Height = 20;
            Dir = Directions.None;
            Mode = Modes.Player;
            EatenFruit = 0;
            Walls = true;
            PathCount = 0;
        }

        //sets the current Mode, only available if snake is dead
        public static void ModeCycle()
        {
            if(Mode == Modes.Player)
            {
                Mode = Modes.AutoPlay1;
            }
            else if(Mode == Modes.AutoPlay1)
            {
                Mode = Modes.AutoPlay2;
            }
            else if(Mode == Modes.AutoPlay2)
            {
                Mode = Modes.BFS;
            }
            else if (Mode == Modes.BFS)
            {
                Mode = Modes.DFS;
            }
            else if (Mode == Modes.DFS)
            {
                Mode = Modes.SBFS;
            }
            else if(Mode == Modes.SBFS)
            {
                Mode = Modes.Astar;
            }
            else if(Mode == Modes.Astar)
            {
                Mode = Modes.Player;
            }
        }
    }
}
