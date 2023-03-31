#nullable enable

namespace Snake
{

    internal class Astar : SearchA
    {
        public int Row;
        public int Col;
        public Dictionary<Square?, bool> open = new();
        public bool[,] close;
        Snake? snake;
        Square? target;
        public Dictionary<Square?, Square> prev = new();
        public List<Square?> path = new();
        readonly int[,] moves = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };
        public Astar(int row, int col)
        {
            Row = row;
            Col = col;
            close = new bool[Row,Col];
        }
        public bool ValidPos(int x, int y)
        {
            if (x >= Row || y >= Col || x < 0 || y < 0)
            {
                return false;
            }
            return snake == null || (!snake.Contains(x, y));
        }
        private Square? Next()
        {
            var best = int.MaxValue;
            Square? next = null;
            foreach (var square in open.Keys)
            {
                var score = square.TotalVal;
                if (score >= best) continue;
                best = score;
                next = square;
            }
            return next;
        }
        public void BacktrackPath(Square? now)
        {
            while (prev.ContainsKey(now))
            {
                path.Add(now);
                now = prev[now];
            }
            path.Reverse();
        }
        public void Search(Square? start)
        {
            open[start] = true;
            start.GetTotal(target);
            start.dist = 0;
            
            while (open.Count > 0)
            {
                var now = Next();
                if (now.X == target.X && now.Y == target.Y)
                {
                    BacktrackPath(now);
                    break;
                }
                open.Remove(now);
                close[now.X, now.Y] = true;
                List<Square?> Adjacent = new();
                for(var i = 0; i < 4; i++)
                {
                    Square? n = new()
                    {
                        X = now.X + moves[i, 0],
                        Y = now.Y + moves[i, 1]
                    };
                    if (ValidPos(n.X, n.Y))
                    {
                        Adjacent.Add(n);
                    }
                }
                foreach(var adj in Adjacent)
                {
                    if (close[adj.X,adj.Y])
                        continue;
                    var distance = now.dist + 1;
                    if (!open.ContainsKey(adj))
                    {
                        open[adj] = true;
                    }
                    else if (distance >= adj.dist)
                        continue;
                    prev[adj] = now;
                    adj.dist = distance;
                    adj.GetTotal(target);
                    adj.TotalVal += distance;
                }



            }
            
        }
        
        public List<Square?> GetPath(Snake snake, Square target)
        {
            this.target = target;
            this.snake = snake;
            Search(snake.N(0));
            return path;
        }
    }
}
