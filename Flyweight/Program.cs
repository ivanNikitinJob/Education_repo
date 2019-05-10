using System;
using System.Text;
using System.Windows.Forms;

namespace Flyweight
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Application.EnableVisualStyles();
            Game game = new Game();
            game.StartGame();
        }

    }
}
