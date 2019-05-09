using System;
using System.Drawing;
using DotImaging;
using System.IO;

namespace Flyweight
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Game game = new Game();
            game.StartGame();
        }

    }
}
