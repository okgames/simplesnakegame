using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Console;

namespace SimpleSnakeGame
{
    class Program
    {
        static void Main()
        {
            while (Menu.Show() != 0)
                Game.Run();
        } 
    }
}