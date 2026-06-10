namespace SnakeGame
{
    public class Game
    {
        private readonly int _width;
        private readonly int _height;
        private readonly Random _random = new();
        private readonly List<Snake> _snakes = new();
        private Obstakel _food = new();

        public Game(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public void AddPlayer(Snake snake)
        {
            _snakes.Add(snake);
        }

        public void Run()
        {
            Console.CursorVisible = false;
            SpawnFood();

            while (_snakes.Any(s => s.IsAlive))
            {
                Draw();
                HandleInput();
                Update();
                Thread.Sleep(80);
            }

            ShowGameOver();
        }

        private void HandleInput()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (_snakes.Count > 0 && _snakes[0].IsAlive)
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow: _snakes[0].QueueDirection("UP"); break;
                        case ConsoleKey.DownArrow: _snakes[0].QueueDirection("DOWN"); break;
                        case ConsoleKey.LeftArrow: _snakes[0].QueueDirection("LEFT"); break;
                        case ConsoleKey.RightArrow: _snakes[0].QueueDirection("RIGHT"); break;
                    }
                }

                if (_snakes.Count > 1 && _snakes[1].IsAlive)
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.W: _snakes[1].QueueDirection("UP"); break;
                        case ConsoleKey.S: _snakes[1].QueueDirection("DOWN"); break;
                        case ConsoleKey.A: _snakes[1].QueueDirection("LEFT"); break;
                        case ConsoleKey.D: _snakes[1].QueueDirection("RIGHT"); break;
                    }
                }
            }
        }

        private void Update()
        {
            foreach (Snake snake in _snakes.Where(s => s.IsAlive))
            {
                snake.Move();

                if (snake.HitsWall(_width, _height) || snake.HitsSelf())
                {
                    snake.IsAlive = false;
                    continue;
                }

                foreach (Snake other in _snakes.Where(s => s != snake))
                {
                    if (snake.HitsOther(other))
                    {
                        snake.IsAlive = false;
                    }
                }

                if (!snake.IsAlive)
                    continue;

                if (snake.EatsFood(_food))
                {
                    snake.Grow();
                    SpawnFood();
                }
                else
                {
                    snake.TrimTail();
                }
            }
        }

        private void SpawnFood()
        {
            do
            {
                _food.Xpos = _random.Next(1, _width - 1);
                _food.Ypos = _random.Next(1, _height - 1);
            }
            while (_snakes.Any(snake => Occupies(snake, _food.Xpos, _food.Ypos)));
        }

        private static bool Occupies(Snake snake, int x, int y)
        {
            for (int i = 0; i < snake.BodyPositions.Count; i += 2)
            {
                if (snake.BodyPositions[i] == x && snake.BodyPositions[i + 1] == y)
                    return true;
            }

            return false;
        }

        private void Draw()
        {
            Console.Clear();
            DrawBorder();
            DrawFood();
            DrawScore();

            foreach (Snake snake in _snakes)
            {
                if (snake.IsAlive)
                    snake.Draw();
            }
        }

        private void DrawBorder()
        {
            Console.ForegroundColor = ConsoleColor.White;

            for (int x = 0; x < _width; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write("■");
                Console.SetCursorPosition(x, _height - 1);
                Console.Write("■");
            }

            for (int y = 0; y < _height; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("■");
                Console.SetCursorPosition(_width - 1, y);
                Console.Write("■");
            }
        }

        private void DrawFood()
        {
            Console.ForegroundColor = _food.schermKleur;
            Console.SetCursorPosition(_food.Xpos, _food.Ypos);
            Console.Write(_food.karakter);
        }

        private void DrawScore()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(2, _height - 1);

            string scoreText = string.Join(" | ", _snakes.Select(s => $"{s.PlayerName}: {s.Score}"));
            Console.Write(scoreText);
        }

        private void ShowGameOver()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(_width / 4, _height / 2);
            Console.WriteLine("KONIEC GRY");

            Console.ForegroundColor = ConsoleColor.White;
            foreach (Snake snake in _snakes)
            {
                Console.SetCursorPosition(_width / 4, _height / 2 + _snakes.IndexOf(snake) + 1);
                Console.WriteLine($"{snake.PlayerName}: {snake.Score} pkt");
            }

            Console.SetCursorPosition(_width / 4, _height / 2 + _snakes.Count + 2);
            Console.WriteLine("Naciśnij dowolny klawisz...");
            Console.ReadKey(true);
        }
    }
}
