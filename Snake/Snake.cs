using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    //used for easier manipulation with directions
    enum Directions
    {
        Left,
        Right,
        Up,
        Down,
        None
    };
    //stores names of different modes
    enum Modes
    {
        Player,
        AutoPlay1, //only efficient in the walls off mode
        AutoPlay2,//useless
        BFS, //Breadth first search for the shortest path to fruit
        DFS, //Depth first search for the shortest path to fruit
        SBFS, //slower,but more durable version of bfs(runs bfs on every tick)
        Astar, //a* pathfinding algorithm
    };

   
    internal class Square
    {
        //coordinates of a singleton(point) 
        public int X;
        public int Y;

        //color of a singleton instance
        public Brush Colour;
        public int TotalVal;
        public int dist;
        //data structure used for representation of a single "pixel" on the gameboard
        public Square()
        {
            X = 0;
            Y = 0;
            Colour = Brushes.Green;
            TotalVal = int.MaxValue;
            dist = 0;
        }
        //assigns total value used for greedily choosing the best option for next square(using step count from start + manhattan distance)
        public void GetTotal(Square end)
        {
            var dx = end.X - X;
            var dy = end.Y - Y;
            var res = Math.Abs(dx) + Math.Abs(dy);
            TotalVal = res;
        }
        //function which sets the coordinates of an instance from a single line
        public void SetCoor(int coorX, int coorY)
        {
            X = coorX;
            Y = coorY;
        }
    }
    //class for snake as an object
    internal class Snake
    {
        public List<Square?> body = new();
        //Indicates whether the snake is alive or not
        public bool alive;
        public Snake(Square? head, int X, int Y, Brush color)
        {
            alive = false ;
            Add(head);
            body[0].SetCoor(X, Y);
            ChangeHeadColor(color);

        }

        //resets the snake
        public void Clear()
        {
            body.Clear();
        }

        //adds one single segment to the body of the snake
        public void Add(Square? segment)
        {
            body.Add(segment);
        }

        //changes the snakes color, except for the head
        public void ChangeBodyColor(Brush color)
        {
            for (var i = 1; i < Length(); i++)
            {
                body[i].Colour = color;
            }
        }
        //Changes only the heads color
        public void ChangeHeadColor(Brush color)
        {
            body[0].Colour = color;
        }
        //returns the Length of a snake
        public int Length() { return body.Count; }

        //returns n-th snakes segment
        public Square? N(int n)
        {
            return body[n];
        }

        //sets the snake status to dead
        public async void Die()
        {
            alive = false;
            Settings.AvgPathLength = Settings.PathCount / Settings.Level;
            var filename = Settings.Mode + "Results.txt";
            var text = Settings.Mode + ":" + Settings.Level + ":" + Settings.AvgPathLength;
            await using StreamWriter file = new(filename, append: true);
            await file.WriteLineAsync(text);
        }
        //checks if given coordinate is a snake coordinate
        public bool Contains(int x, int y)
        {
            for (var i = 1; i < Length(); i++)
            {
                if (body[i].X == x && body[i].Y == y)
                {
                    return true;
                }
            }
            return false;
        }

      
    }
}
