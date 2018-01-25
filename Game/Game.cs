using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Console;

namespace SimpleSnakeGame
{
    public class Game
    {
        private static int baseFrequency = 50;

        public static void Run()
        {
            WindowHeight = 25;
            WindowWidth = 80;

            var rand = new Random();

            var score = 0;

            var head = new Pixel(WindowWidth / 2, WindowHeight / 2, ConsoleColor.Red, '☺');
            var berry = new Pixel(rand.Next(1, WindowWidth - 2), rand.Next(1, WindowHeight - 2), ConsoleColor.DarkMagenta, '☺');

            var body = new List<Pixel>();

            var currentMovement = Direction.Right;

            var gameover = false;

            OutputEncoding = System.Text.Encoding.UTF8;
            ForegroundColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.White;
            CursorVisible = false;

            Clear();
            DrawBorder();


            while (true)
            {
                gameover |= (head.XPos == WindowWidth - 1 || head.XPos == 0 || head.YPos == WindowHeight - 1 || head.YPos == 0);

                if (berry.XPos == head.XPos && berry.YPos == head.YPos)
                {
                    score++;
                    berry.XPos = rand.Next(1, WindowWidth - 2);
                    berry.YPos = rand.Next(1, WindowHeight - 2);
                }

                for (int i = 0; i < body.Count; i++)
                {
                    DrawPixel(body[i]);
                    gameover |= (body[i].XPos == head.XPos && body[i].YPos == head.YPos);
                }

                gameover |= currentMovement == Direction.Exit;

                if (gameover)
                {
                    break;
                }

                DrawPixel(head);
                DrawPixel(berry);

                var sw = Stopwatch.StartNew();
                var gameFrequency = baseFrequency;
                if (currentMovement == Direction.Up || currentMovement == Direction.Down)
                    gameFrequency = baseFrequency * 2;
                while (sw.ElapsedMilliseconds <= gameFrequency)
                {
                    currentMovement = ReadMovement(currentMovement);
                }

                foreach (var pixel in body)
                    ClearPixel(pixel);
                ClearPixel(head);

                body.Add(new Pixel(head.XPos, head.YPos, ConsoleColor.Green, '☺'));

                switch (currentMovement)
                {
                    case Direction.Up:
                        head.YPos--;
                        break;
                    case Direction.Down:
                        head.YPos++;
                        break;
                    case Direction.Left:
                        head.XPos--;
                        break;
                    case Direction.Right:
                        head.XPos++;
                        break;
                }

                if (body.Count > score)
                {
                    body.RemoveAt(0);
                }
            }

            SetCursorPosition(WindowWidth / 5, WindowHeight / 2);
            WriteLine($"Game over, Score: {score}");
            SetCursorPosition(WindowWidth / 5, WindowHeight / 2 + 1);
            WriteLine($"Press any key to exit to main menu");
            ReadKey();
        }

        private static Direction ReadMovement(Direction movement)
        {
            if (KeyAvailable)
            {
                var key = ReadKey(true).Key;
                if (key == ConsoleKey.Escape)
                    movement = Direction.Exit;
                if (key == ConsoleKey.UpArrow && movement != Direction.Down)
                {
                    movement = Direction.Up;
                }
                else if (key == ConsoleKey.DownArrow && movement != Direction.Up)
                {
                    movement = Direction.Down;
                }
                else if (key == ConsoleKey.LeftArrow && movement != Direction.Right)
                {
                    movement = Direction.Left;
                }
                else if (key == ConsoleKey.RightArrow && movement != Direction.Left)
                {
                    movement = Direction.Right;
                }
            }

            return movement;
        }

        private static void DrawPixel(Pixel pixel)
        {
            var oldForeground = ForegroundColor;
            SetCursorPosition(pixel.XPos, pixel.YPos);
            ForegroundColor = pixel.ScreenColor;
            Write(pixel.Symbol);
            SetCursorPosition(0, 0);
            ForegroundColor = oldForeground;
        }

        private static void ClearPixel(Pixel pixel)
        {
            DrawPixel(new Pixel(pixel.XPos, pixel.YPos, pixel.ScreenColor, ' '));
        }

        private static void DrawBorder()
        {
            var pixel = new Pixel(0, 0, ConsoleColor.Black);
            for (int i = 0; i < WindowWidth; i++)
            {
                pixel.XPos = i;
                pixel.YPos = 0;
                DrawPixel(pixel);

                pixel.XPos = i;
                pixel.YPos = WindowHeight - 1;
                DrawPixel(pixel);
            }

            for (int i = 0; i < WindowHeight; i++)
            {
                pixel.XPos = 0;
                pixel.YPos = i;
                DrawPixel(pixel);

                pixel.XPos = WindowWidth - 1;
                pixel.YPos = i;
                DrawPixel(pixel);
            }
        }

        private class Pixel
        {
            public Pixel(int xPos, int yPos, ConsoleColor color, char symbol = '█')
            {
                XPos = xPos;
                YPos = yPos;
                Symbol = symbol;
                ScreenColor = color;
            }

            public char Symbol { get; set; }
            public int XPos { get; set; }
            public int YPos { get; set; }
            public ConsoleColor ScreenColor { get; set; }
        }

        private enum Direction
        {
            Up,
            Down,
            Right,
            Left,
            Exit
        }

    }
}
