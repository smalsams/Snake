using System.Collections;
namespace Snake
{
    public partial class Form1 : Form
    {
        private Snake snake; //snake object
        private Square fruit = new();//fruit object
        int maxWidth; // maximal X coordinate
        int maxHeight; // maximal Y coordinate
        Modes newMode; //used for the modecycle function in settings
        private static Hashtable keys; // Hashtable for keyboard input
        public int cycle; //is supposed to count up until it reaches the path length
        private List<Square?> path; //is supposed to contain a path to fruit
        public Random random; //used for snake spawning and fruit generation

        public Form1()
        {
            InitializeComponent();
            keys = new Hashtable();
            new Settings();
            cycle = 0;
            random = new Random();
            maxWidth = Gameboard.Size.Width / Settings.Width;
            maxHeight = Gameboard.Size.Height / Settings.Height;
            timer.Tick += Loop; 
            timer.Start();

            Start();

        }
        //checks if the given key was pressed
        private static bool WasPressed(Keys key)
        {
            if (keys[key] == null)
            {
                return false;
            }

            var v = (bool)keys[key];
            return v;
        }


        //initiates the game instance
        private void Start()
        {
            new Settings();
            mode.Text = newMode.ToString();
            Settings.Mode = newMode;
            timer.Interval = 50 / Settings.Speed;
            GOsign.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            Square? head = new(); 
            var headx = random.Next(0, maxWidth);
            var heady = random.Next(0, maxHeight);
            snake = new Snake(head, headx, heady, Brushes.White);
            FruitGen();
        }


        //responsible for the graphics
        private void Draw(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            if (snake.alive == true)
            {
                for (var i = 0; i < SnakeLength(); i++)
                {
                    g.FillRectangle(snake.N(i).Colour, new Rectangle(snake.N(i).X * Settings.Width, snake.N(i).Y * Settings.Height, Settings.Width, Settings.Height));
                  
                }
                g.FillRectangle(fruit.Colour, new Rectangle(fruit.X * Settings.Width, fruit.Y * Settings.Height, Settings.Width, Settings.Height));
            }
            else
            {
                GOsign.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
            }
        }
        

        //moves the snake according to its pre-set direction and determines its next state accordingly
        private void ChangePos()
        {
            for (var i = SnakeLength()-1; i >= 0; i--)
            {
                if (i == 0)
                {
                    HeadMove(Settings.Dir);

                    if (Settings.Walls == false)
                    {
                        WallMove();
                    }
                    else
                    {
                        if (IsWallHit(GetHead()))
                        {
                            snake.Die();
                            GOsign.Text = "Game Over";
                        }
                    }
                    if (IsSnakeHit(GetHead()))
                    {
                        snake.Die();
                        GOsign.Text = "Game Over";
                    }
                    if (IsEatable())
                    {
                        Grow();
                    }
                }
                else
                {
                    GetSeg(i).SetCoor(GetSeg(i-1).X, GetSeg(i-1).Y);
                }
            }
        }


        //makes the snake grow by adding one singleton(segment) to the snake list
        private void Grow()
        {
            NewSegment();
            Settings.EatenFruit++;
            if (Settings.EatenFruit >= 1)
            {
                LevelUp();
            }
            FruitGen();
        }


        //appends a segment to the snake body
        private void NewSegment()
        {
            Square? segment = new();
            if (snake.Length() > 1)
            {
                segment.Colour = snake.body[snake.Length()-1].Colour;
            }
            segment.SetCoor(snake.N(SnakeLength() - 1).X, snake.N(SnakeLength() - 1).Y);
            snake.Add(segment);
        }

     

        //Finds out if wall was hit
        private bool IsWallHit(Square? square)
        {
            return square.X < 0 || square.Y < 0 || square.X >= maxWidth || square.Y >= maxHeight;
        }

        //finds out if snake self-collided
        private bool IsSnakeHit(Square? square)
        {
            return snake.Contains(square.X, square.Y);
        }
        //returns true if snake head is on fruit position
        private bool IsEatable()
        {
            return GetHead().X == fruit.X && GetHead().Y == fruit.Y;
        }
       
        
        //sets the snake moving according to a direction
        private void HeadMove(Directions dir)
        {
            switch (dir)
            {
                case Directions.Left:
                    GetHead().X--;
                    break;
                case Directions.Right:
                    GetHead().X++;
                    break;
                case Directions.Up:
                    GetHead().Y--;
                    break;
                case Directions.Down:
                    GetHead().Y++;
                    break;
                case Directions.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }
        }

        //move in no wall mode
        private void WallMove()
        {
            if (GetHead().X < 0)
            {
                GetHead().X = maxWidth;
            }
            else if (GetHead().Y < 0)
            {
                GetHead().Y = maxHeight-1;
            }
            else if (GetHead().X > maxWidth)
            {
                GetHead().X = 0;
            }
            else if (GetHead().Y > maxHeight)
            {
                GetHead().Y = 0;
            }
        }

        //main loop, which updates the screen on every tick
        private void Loop(object sender, EventArgs e)
        {
            TickUpdate(Settings.Mode);
            Gameboard.Invalidate();
        }


        //action after pressing a key
        private void KeyPush(object sender, KeyEventArgs e)
        {
            keys[e.KeyCode] = true ;
        }


        //action after releasing a key
        private void KeyRelease(object sender, KeyEventArgs e)
        {
            keys[e.KeyCode] = false;
        }

        //functions that return basic snake properties and body parts
        private int SnakeLength() { return snake.Length(); }
        private Square? GetSeg(int n) { return snake.N(n); }
        private Square? GetHead() { return snake.N(0); }


        //increases the level by one and changes the settings accordingly
        private void LevelUp()
        {
            Settings.EatenFruit = 0;
            Settings.Level++;
            switch (Settings.Level)
            {
                case < 4:
                    Settings.Speed++;
                    timer.Interval = 50 / Settings.Speed*3/2;
                    break;
                case >= 4 and < 8:
                    Settings.Speed++;
                    snake.ChangeBodyColor(Brushes.Purple);
                    timer.Interval = 50 / Settings.Speed*3/2;
                    snake.ChangeHeadColor(Brushes.Black);
                    break;
                default:
                    snake.ChangeBodyColor(Brushes.Orange);
                    snake.ChangeHeadColor(Brushes.Yellow);
                    break;
            }
        }

        //responsible for the fruit generation
        private void FruitGen()
        {
            fruit = new Square();
            var nx = random.Next(0, maxWidth);
            var ny = random.Next(0, maxHeight);
            while ((snake.Contains(nx,ny) == true) || (snake.body[0].X == nx && snake.body[0].Y == ny)) { 
                nx = random.Next(0, maxWidth);
                ny = random.Next(0, maxHeight);

            }
            fruit.SetCoor(nx,ny);
            fruit.Colour = Brushes.Red;
        }

        //function that gets either user-generated or auto-generated input every tick and sends instructions to move functions
        private void TickUpdate(Modes Mode)
        {
            if (snake.alive == false)
            {
                timer.Interval = 50;
                if (WasPressed(Keys.Space))
                {
                    Start();
                    snake.alive = true;
                }
                else if (WasPressed(Keys.M))
                {
                    Settings.ModeCycle();
                    newMode = Settings.Mode;
                    mode.Text = Settings.Mode.ToString();
                }
            }
            else
            {
                switch (Mode)
                {
                    case Modes.Player:
                    {
                        Settings.Walls = true;
                        if (WasPressed(Keys.A) && Settings.Dir != Directions.Right)
                        {
                            Settings.Dir = Directions.Left;
                        }
                        else if (WasPressed(Keys.D) && Settings.Dir != Directions.Left)
                        {
                            Settings.Dir = Directions.Right;
                        }
                        else if (WasPressed(Keys.W) && Settings.Dir != Directions.Down)
                        {
                            Settings.Dir = Directions.Up;
                        }
                        else if (WasPressed(Keys.S) && Settings.Dir != Directions.Up)
                        {
                            Settings.Dir = Directions.Down;
                        }

                        break;
                    }
                    case Modes.AutoPlay1:
                    {
                        Settings.Walls = false;
                        if (Settings.Dir == Directions.None)
                        {
                            Settings.Dir = Directions.Right;
                        }
                        if (GetHead().X == 0)
                        {
                            if (Settings.Dir == Directions.Left)
                            {
                                Settings.Dir = Directions.Up;
                            }
                            else if (Settings.Dir == Directions.Up)
                            {
                                Settings.Dir = Directions.Right;
                            }
                        }
                        if (GetHead().X == maxWidth - 1)
                        {
                            if (Settings.Dir == Directions.Right)
                            {
                                Settings.Dir = Directions.Up;
                            }
                            else if (Settings.Dir == Directions.Up)
                            {
                                Settings.Dir = Directions.Left;
                            }
                        }

                        break;
                    }
                    case Modes.AutoPlay2:
                    {
                        Settings.Walls = false;
                        if (Settings.Dir == Directions.None)
                        {
                            Settings.Dir = Directions.Right;
                        }
                        if (GetHead().X == fruit.X)
                        {
                            if (GetHead().Y < fruit.Y)
                            {
                                Settings.Dir = Directions.Down;
                            }
                            else if (GetHead().Y > fruit.Y)
                            {
                                Settings.Dir = Directions.Up;
                            }
                        }
                        else if (GetHead().Y == fruit.Y)
                        {
                            if (GetHead().X < fruit.X)
                            {
                                Settings.Dir = Directions.Right;
                            }
                            else if (GetHead().X > fruit.X)
                            {
                                Settings.Dir = Directions.Left;
                            }
                        }

                        break;
                    }
                    case Modes.BFS:
                    {
                        Settings.Walls = true;
                        if (path == null || cycle >= path.Count-1)
                        {
                            SearchA alg = new Bfs(maxWidth, maxHeight);
                            path = alg.GetPath(snake, fruit);
                            Settings.PathCount += path.Count;
                            path.Reverse();
                            cycle = 0;
                        }
                        try
                        {
                            Settings.Dir = SetDir(path[cycle+1]);
                        }
                        catch (NullReferenceException)
                        {
                            snake.Die();
                            path.Clear();
                            cycle = 0;
                            GOsign.Text = "SNAKE CAN NOT FIND FOOD";
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            snake.Die();
                            path.Clear();
                            cycle = 0;
                            GOsign.Text = "SNAKE CAN NOT FIND FOOD";
                        }
                        cycle++;
                        break;
                    }
                    //standard dfs
                    case Modes.DFS:
                    {
                        Settings.Walls = true;
                        if (path is null || cycle >= path.Count-1) { 
                            SearchA alg = new Dfs(maxWidth, maxHeight);
                            path = alg.GetPath(snake, fruit);
                            Settings.PathCount += path.Count;
                            path.Reverse();
                            if (Settings.Dir == Directions.Left)
                            {
                                cycle = -1;
                            }
                            else
                            {
                                cycle = 0;
                            }
                       
                        }

                        try
                        {
                            Settings.Dir = SetDir(path[cycle + 1]);
                        }
                        catch (NullReferenceException)
                        {
                            snake.Die();
                            path.Clear();
                            cycle = 0;
                            GOsign.Text = "SNAKE CAN NOT FIND FOOD";
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            snake.Die();
                            path.Clear();
                            cycle = 0;
                            GOsign.Text = "SNAKE CAN NOT FIND FOOD";
                        }
                        cycle++;
                        break;
                    }
                    case Modes.SBFS:
                    {
                        Settings.Walls = true;
                        SearchA alg = new Bfs(maxWidth, maxHeight);
                        path = alg.GetPath(snake, fruit);
                        Settings.PathCount += 1;
                        cycle = path.Count - 1;
                        try
                        {
                            Settings.Dir = SetDir(path[cycle - 1]);
                        }
                        catch (NullReferenceException)
                        {
                            snake.Die();
                            path.Clear();
                            cycle = 0;
                            GOsign.Text = "SNAKE CAN NOT FIND FOOD";
                        }
                        catch (ArgumentOutOfRangeException) { 
                            snake.Die();
                            path.Clear();
                            cycle= 0;
                            GOsign.Text = "SNAKE CAN NOT FIND FOOD";
                        }

                        break;
                    }
                    case Modes.Astar:
                    {
                        Settings.Walls = true;
                        if (path == null || cycle >= path.Count - 1)
                        {
                            SearchA alg = new Astar(maxWidth, maxHeight);
                            path = alg.GetPath(snake, fruit);
                            Settings.PathCount += path.Count;
                            cycle = 0;
                        }
                        try
                        {
                            Settings.Dir = SetDir(path[cycle]);
                        }
                        catch (NullReferenceException)
                        {
                            snake.Die();
                            path.Clear();
                            cycle = 0;
                            GOsign.Text = "SNAKE CAN NOT FIND FOOD";
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            snake.Die();
                            path.Clear();
                            cycle = 0;
                            GOsign.Text = "SNAKE CAN NOT FIND FOOD";
                        }
                        cycle++;
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Mode), Mode, null);
                }

                level.Text = Settings.Level.ToString();
                ChangePos();
            }
        }

        //sets the direction from a target position
        private Directions SetDir(Square? step)
        {
            if (step.X > snake.N(0).X && step.Y == snake.N(0).Y)
            {
                return Directions.Right;
            }
            if (step.X < snake.N(0).X && step.Y == snake.N(0).Y)
            {
                
                return Directions.Left;
            }
            if (step.X == snake.N(0).X && step.Y < snake.N(0).Y)
            {
             
                return Directions.Up;
            }
            if (step.X == snake.N(0).X && step.Y > snake.N(0).Y)
            {
              
                return Directions.Down;
            }
            return Directions.None;
        }



    }
}