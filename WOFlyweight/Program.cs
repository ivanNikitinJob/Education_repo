using System;
using System.Text;
using System.Windows.Forms;
using Flyweight;

namespace WOFlyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Application.EnableVisualStyles();
            Game game = new Game();
            game.StartGame();
        }
    }
}
