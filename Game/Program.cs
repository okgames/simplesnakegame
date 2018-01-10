using System;
using System.Net;
using System.Runtime.InteropServices.ComTypes;

namespace Game
{
    public class Program
    {
        private static char[,] GenerateEmptyField(int width, int height)
        {
            var field = new char[width, height];
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    field[i, j] = '.';
                }
            }
            return field;
        }

        private static void ShowField(char[,] field, int width, int height)
        {
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    Console.Write(field[i, j]);
                }
            }
            Console.SetCursorPosition(0, 0);
        }

        static void Main(string[] args)
        {
            .Console.CursorVisible = false;
            Console.SetWindowSize(80, 24);
            Console.SetBufferSize(80, 24);
            var field = GenerateEmptyField(80, 24);
            ShowField(field, 80, 24);
            Console.ReadKey(true);
        }
    }
}