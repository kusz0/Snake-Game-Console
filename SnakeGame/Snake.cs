namespace SnakeGame
{
    public class Snake
    {
        public Pixel Head { get; }
        public List<int> BodyPositions { get; }
        public string Direction { get; set; }
        public string PendingDirection { get; set; }
        public ConsoleColor Color { get; set; }
        public int Score { get; private set; }
        public bool IsAlive { get; set; } = true;
        public string PlayerName { get; }

        private static readonly Dictionary<string, string> Opposites = new()
        {
            ["UP"] = "DOWN",
            ["DOWN"] = "UP",
            ["LEFT"] = "RIGHT",
            ["RIGHT"] = "LEFT"
        };

        public Snake(int startX, int startY, ConsoleColor color, string playerName, string startDirection = "RIGHT")
        {
            Head = new Pixel { xPos = startX, yPos = startY, schermKleur = color, karacter = "■" };
            BodyPositions = new List<int> { startX, startY };
            Direction = startDirection;
            PendingDirection = startDirection;
            Color = color;
            PlayerName = playerName;
        }

        public void QueueDirection(string newDirection)
        {
            if (Opposites[Direction] == newDirection)
                return;

            PendingDirection = newDirection;
        }

        public void Move()
        {
            Direction = PendingDirection;

            switch (Direction)
            {
                case "UP": Head.yPos--; break;
                case "DOWN": Head.yPos++; break;
                case "LEFT": Head.xPos--; break;
                case "RIGHT": Head.xPos++; break;
            }

            BodyPositions.Insert(0, Head.xPos);
            BodyPositions.Insert(1, Head.yPos);
        }

        public void Grow()
        {
            Score++;
        }

        public void TrimTail()
        {
            if (BodyPositions.Count <= 2)
                return;

            BodyPositions.RemoveAt(BodyPositions.Count - 1);
            BodyPositions.RemoveAt(BodyPositions.Count - 1);
        }

        public bool HitsWall(int width, int height)
        {
            return Head.xPos <= 0 || Head.xPos >= width - 1 || Head.yPos <= 0 || Head.yPos >= height - 1;
        }

        public bool HitsSelf()
        {
            for (int i = 2; i < BodyPositions.Count; i += 2)
            {
                if (Head.xPos == BodyPositions[i] && Head.yPos == BodyPositions[i + 1])
                    return true;
            }

            return false;
        }

        public bool HitsOther(Snake other)
        {
            for (int i = 0; i < other.BodyPositions.Count; i += 2)
            {
                if (Head.xPos == other.BodyPositions[i] && Head.yPos == other.BodyPositions[i + 1])
                    return true;
            }

            return false;
        }

        public bool EatsFood(Obstakel food)
        {
            return Head.xPos == food.Xpos && Head.yPos == food.Ypos;
        }

        public void Draw()
        {
            Console.ForegroundColor = Color;
            for (int i = 0; i < BodyPositions.Count; i += 2)
            {
                Console.SetCursorPosition(BodyPositions[i], BodyPositions[i + 1]);
                Console.Write("■");
            }
        }
    }
}
