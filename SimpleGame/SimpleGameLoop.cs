using SimpleGameLoop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame
{
    public class SimpleSnakeGameLoop : SimpleLoop, IGameLoop
    {
        private static ICollection<string> startMenu = new []
        {
            @"          _____ _                 _                            _                ",
            @"         /  ___(_)               | |                          | |               ",
            @"         \ `--. _ _ __ ___  _ __ | | ___       ___ _ __   __ _| | _____         ",
            @"          `--. \ | '_ ` _ \| '_ \| |/ _ \     / __| '_ \ / _` | |/ / _ \        ",
            @"         /\__/ / | | | | | | |_) | |  __/     \__ \ | | | (_| |   <  __/        ",
            @"         \____/|_|_| |_| |_| .__/|_|\___|     |___/_| |_|\__,_|_|\_\___|        ",
            @"                           | |                                                  ",
            @"                           |_|                                                  ",
            @"                                                                                ",
            @"                                                                                ",
            @"                                                                                ",
            @"                                                                                ",
            @"                                                                                ",
            @"                                                                                ",
            @"                                                                                ",
            @"                                                                                ",
            @"                                                                                ",
            @"                                                                                ",
            @"                                                                                ",
            @"                                                                                ",
            @"                                                                                ",
            @"                                                                                ",
            @"                                                                                ",
            @"                                    HELLO                                       "
        };

        public override void ExitGame()
        {
            Console.WriteLine("Thank you for playing our game! Press any key to exit");
            Console.ReadKey(true);
        }

        public override int ShowStartScreen()
        {
            Console.SetBufferSize(80, 25);
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            foreach (var line in startMenu.Take(23))
                Console.Write(line);
            Console.Write(startMenu.ElementAt(23));
            Console.MoveBufferArea(0, 23, 80, 1, 0, 24);
            Console.SetCursorPosition(0, 24);
            Console.Write(startMenu.ElementAt(24));
            Console.SetCursorPosition(0, 0);
            if (Console.ReadKey(true).KeyChar == '1')
                return 1;
            else
                return 0;
        }

        public override int StartGame()
        {
            Console.WriteLine("Welcome to the game. Press any key to exit the game");
            Console.ReadKey(true);
            return 0;
        }
    }
}
