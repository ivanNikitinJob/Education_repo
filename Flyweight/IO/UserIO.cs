using DotImaging;
using Flyweight.Enums;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Flyweight.IO
{
    public static class UserIO
    {
        public static readonly string userControllReadme = 
@"Press 'S' to see stats. 
Press 'A' to build.
Press 'Q' or 'E' to look on your city plans and plans schemas respectively. 
Press 'F' to finish the game. 
Press 'R' to destroy your city and start again. 
(Dont press anything else (seriously))";
        public static readonly string controllYN = "Press 'Y' to accept or 'N' to reject";

        public static string GetUserAnswer(string question)
        {
            Console.WriteLine(question);
            string answer = Console.ReadLine();
            Console.WriteLine();
            return answer;
        }

        public static BuildingType GetBuildingType(string question)
        {
            Console.WriteLine(question);
            Console.WriteLine($"Available types: ");

            foreach (var type in Enum.GetValues(typeof(BuildingType)))
            {
                Console.WriteLine($"{type.ToString()} = {(int)type}");
            }

            return (BuildingType)Convert.ToInt32(Console.ReadLine());
        }

        public static Image GetImage(string question)
        {
            Console.WriteLine(question);
            string file = UI.OpenFile();
            UserIO.SayToUser($"Selected file: {file} \n");
            Image img = Image.FromFile(file);
            return img;
        }

        public static ConsoleKey GetUserControll()
        {
            Console.WriteLine(userControllReadme);
            var userInput = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
            return userInput.Key;
        }

        public static bool? GetUserYN()
        {
            Console.WriteLine(controllYN);
            var key = Console.ReadKey().Key;
            Console.WriteLine();
            if (key == ConsoleKey.Y)
            {
                return true;
            }
            if(key == ConsoleKey.N)
            {
                return false;
            }
            return null;
        }

        public static void SayToUser(string phrase)
        {
            Console.WriteLine(phrase);
        }

        public static void ShowImage(Image img)
        {
            PicBox imgForm = new PicBox();
            imgForm.SetPicture(img);
            imgForm.Size = img.Size;
            Application.Run(imgForm);
        }
    }
}
