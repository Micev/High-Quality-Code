using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class Minesweeper
    {
        public static void Main()
        {
            const int MaxPoints = 35;

            string command = string.Empty;
            char[,] field = CreatePlayingField();
            char[,] mines = PutMines();
            int pointCounter = 0;          
            int row = 0;
            int column = 0;
            bool isOnMine = false;
            bool isGameStart = true;
            bool isGameEnd = false;
            List<Player> players = new List<Player>(6);

            do
            {
                if (isGameStart)
                {
                    Console.WriteLine(
                        "Let's play “Mini4KI”. Try yourself to find fiels withoult mines.\n"
                        + "Command 'top' show player result, 'restart' start new game, 'exit' exit from game.");
                    Draw(field);
                    isGameStart = false;
                }

                Console.Write("Enter row and column : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out column)
                        && row <= field.GetLength(0) && column <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Charts(players);
                        break;
                    case "restart":
                        field = CreatePlayingField();
                        mines = PutMines();
                        Draw(field);
                        isOnMine = false;
                        isGameStart = false;
                        break;
                    case "exit":
                        Console.WriteLine("Thanks for your playing!\nBuy.");
                        break;
                    case "turn":
                        if (mines[row, column] != '*')
                        {
                            if (mines[row, column] == '-')
                            {
                                Move(field, mines, row, column);
                                pointCounter++;
                            }

                            if (MaxPoints == pointCounter)
                            {
                                isGameEnd = true;
                            }
                            else
                            {
                                Draw(field);
                            }
                        }
                        else
                        {
                            isOnMine = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command\n");
                        break;
                }

                if (isOnMine)
                {
                    Draw(mines);
                    Console.Write("\nBoom! You dead like a hero with {0} points. " + "Enter your Username: ", pointCounter);
                    string userName = Console.ReadLine();
                    Player player = new Player(userName, pointCounter);
                    if (players.Count < 5)
                    {
                        players.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i].Points < player.Points)
                            {
                                players.Insert(i, player);
                                players.RemoveAt(players.Count - 1);
                                break;
                            }
                        }
                    }

                    players.Sort((Player r1, Player r2) => r2.Name.CompareTo(r1.Name));
                    players.Sort((Player r1, Player r2) => r2.Points.CompareTo(r1.Points));
                    Charts(players);

                    field = CreatePlayingField();
                    mines = PutMines();
                    pointCounter = 0;
                    isOnMine = false;
                    isGameStart = true;
                }

                if (isGameEnd)
                {
                    Console.WriteLine("\nCongratulation! You found all 35 cells withoult any blood.");
                    Draw(mines);
                    Console.WriteLine("Enter your Nickname: ");
                    string name = Console.ReadLine();
                    Player points = new Player(name, pointCounter);
                    players.Add(points);
                    Charts(players);
                    field = CreatePlayingField();
                    mines = PutMines();
                    pointCounter = 0;
                    isGameEnd = false;
                    isGameStart = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria");
            Console.WriteLine("Buy.");
            Console.Read();
        }

        private static void Charts(List<Player> points)
        {
            Console.WriteLine("\nPoints:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, points[i].Name, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void Move(char[,] field, char[,] mines, int row, int column)
        {
            char Pointsmines = Points(mines, row, column);
            mines[row, column] = Pointsmines;
            field[row, column] = Pointsmines;
        }

        private static void Draw(char[,] board)
        {
            int RRR = board.GetLength(0);
            int KKK = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < RRR; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < KKK; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayingField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PutMines()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '-';
                }
            }

            List<int> minesList = new List<int>();
            while (minesList.Count < 15)
            {
                Random random = new Random();
                int randomPosition = random.Next(50);
                if (!minesList.Contains(randomPosition))
                {
                    minesList.Add(randomPosition);
                }
            }

            foreach (int item in minesList)
            {
                int column = item / boardColumns;
                int row = item % boardColumns;
                if (row == 0 && item != 0)
                {
                    column--;
                    row = boardColumns;
                }
                else
                {
                    row++;
                }

                board[column, row - 1] = '*';
            }

            return board;
        }



        private static char Points(char[,] board, int row, int column)
        {
            int points = 0;
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);

            if (row - 1 >= 0)
            {
                if (board[row - 1, column] == '*')
                {
                    points++;
                }
            }

            if (row + 1 < rows)
            {
                if (board[row + 1, column] == '*')
                {
                    points++;
                }
            }

            if (column - 1 >= 0)
            {
                if (board[row, column - 1] == '*')
                {
                    points++;
                }
            }

            if (column + 1 < columns)
            {
                if (board[row, column + 1] == '*')
                {
                    points++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (board[row - 1, column - 1] == '*')
                {
                    points++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < columns))
            {
                if (board[row - 1, column + 1] == '*')
                {
                    points++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (board[row + 1, column - 1] == '*')
                {
                    points++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < columns))
            {
                if (board[row + 1, column + 1] == '*')
                {
                    points++;
                }
            }

            return char.Parse(points.ToString());
        }
    }
}