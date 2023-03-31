using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    //connects the bfs,dfs,astar classes to form(could be done with abstract classes)
    internal interface SearchA
    {
        public List<Square?> GetPath(Snake snake, Square target);
    }
}
