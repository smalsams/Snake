using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    internal class Bfs : SearchA
    {
        bool[,] visited;
        Snake snake;
        Square Fruit;
        List<Square?> path;
        int Row, Col;
        Square?[,] previous;
        readonly int[,] moves = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
        public Bfs(int row, int col)
        {
            Row = row;
            Col = col;
            visited = new bool[Row + 1, Col + 1];
            previous = new Square?[Row + 1, Col + 1];
            path = new List<Square?>();
            for (var i = 0; i < Row; i++)
            {
                for (var j = 0; j < Col; j++)
                {
                    visited[i, j] = false;
                    previous[i, j] = null;
                }
            }
        }
        //checks if given position is visited and if is dangerous
        public bool ValidPos(int x, int y, bool[,] visited)
        {
            if(x>=Row || y >= Col || x<0 || y<0)
            {
                return false;
            }
            if ((snake.Contains(x,y)) || (snake.N(0).X == x && snake.N(0).Y == y))
            {
                return false;
            }
            return !visited[x, y];
        }
        //creates path from a position of the target
        public void BacktrackPath(int x, int y)
        {
            var step = new Square
            {
                X = x,
                Y = y
            }; 
            path.Add(step);
            for (var newStep = previous[x, y]; newStep != null; newStep = previous[newStep.X, newStep.Y])
            {
                path.Add(newStep);
            }
        }
        
        //BFS algorithm
        public void Search(int x, int y)
        {
            Queue<Square?> q = new();
            visited[x, y] = true;
            var c = new Square
            {
                X = x,
                Y = y
            };
            q.Enqueue(c);
            while (q.Count > 0)
            {
                var currentPos = q.Peek();
                x = currentPos.X;
                y = currentPos.Y;
                if (x == Fruit.X && y == Fruit.Y)
                {
                    BacktrackPath(x, y);
                    break;
                }
                q.Dequeue();
                for (var i = 0; i<4; i++)
                {
                    if (!ValidPos(x + moves[i, 0], y + moves[i, 1], visited)) continue;
                    visited[x + moves[i,0],y+moves[i,1]] = true;
                    var newC = new Square
                    {
                        X = x + moves[i, 0],
                        Y = y + moves[i, 1]
                    };
                    q.Enqueue(newC);
                    previous[x + moves[i,0], y+moves[i,1]] = currentPos;
                }
               



            }

        }

        //returns the path
        public List<Square?> GetPath(Snake snake, Square target)
        {
            this.Fruit = target;
            this.snake = snake;
            Search(snake.N(0).X, snake.N(0).Y);
            return path;
        }

    }


}