using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Dfs : SearchA
    {
        bool[,] visited;
        Snake snake;
        Square target;
        List<Square?> path = new();
        int Row, Col;
        readonly int[,] moves = { { 1, 0 }, { -1, 0 }, { 0, -1 }, { 0, 1 } };
        public Dfs(int row, int col)
        {
            Row = row;
            Col = col;
            visited = new bool[Row + 1, Col + 1];
            for (var i = 0; i < Row; i++)
            {
                for (var j = 0; j < Col; j++)
                {
                    visited[i, j] = false;
                }
            }
        }
        //checks if given position is visited and if is dangerous
        public bool ValidPos(int x, int y, bool[,] visited)
        {
            if (x >= Row || y >= Col || x < 0 || y < 0)
            {
                return false;
            }
            return !visited[x, y];
        }

        //dfs algorithm
        public int Search(int x, int y, bool[,] visited)
        {
            if(ValidPos(x, y, visited) == false)  return -1; 
            visited[x, y] = true;
            if(target.X == x && target.Y == y)
            {
                var a = new Square
                {
                    X = x,
                    Y = y
                };
                path.Add(a);
                return 1;

            }

            
            for (var i = 0; i < 4; ++i)
            {
                if (snake.Contains(x+moves[i,0], y+moves[i,1]))
                {
                    return -1;
                }

                if (Search(x + moves[i, 0], y + moves[i, 1], visited) != 1) continue;
                var a = new Square
                {
                    X = x,
                    Y = y
                };
                path.Add(a);
                return 1;
            }
            
            return 0;
        }
        //dfs initialization(preventing snake from running into itself)
        public void DSearch(int x, int y)
        {
            if (Settings.Dir == Directions.Left)
            {
                if (ValidPos(x, y + 1, visited))
                {
                    y++;
                }
                else if (ValidPos(x, y - 1, visited)){
                    y--;
                }
            }
            Search(x, y, visited);
        }
        public List<Square?> GetPath(Snake snake, Square target)
        {
            this.snake = snake;
            this.target = target;
            DSearch(snake.N(0).X, snake.N(0).Y);
            return path;
        }
    }
}
