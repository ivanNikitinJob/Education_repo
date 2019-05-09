using DotImaging;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Flyweight
{
    public static class UserIO
    {
        public static readonly string userControllReadme = 
            @"Press 'S' to see stats. 
Press 'A' to build.
Press 'F' to finish the game. 
Press 'R' to destroy your city and start again. 
Press 'Q' or 'E' to look on your city plans and plans schemas respectively. 
(Dont press anything else (seriously))";
        public static readonly string controllYN = "Press 'Y' to accept or 'N' to reject";

        public static string GetUserAnswer(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public static BuildingType GetBuildingType(string question)
        {
            Console.WriteLine(question);
            Console.WriteLine($"Available types: ");
            foreach (var typeName in Enum.GetNames(typeof(BuildingType)))
            {
                Console.WriteLine($"{typeName}");
            }

            return (BuildingType)Convert.ToInt32(Console.ReadLine());
        }

        public static Image GetImage(string question)
        {
            Console.WriteLine(question);
            string file = UI.OpenFile();
            Image img = Image.FromFile(file);
            return img;
        }

        public static ConsoleKey GetUserControll()
        {
            Console.WriteLine(userControllReadme);
            var userInput = Console.ReadKey();
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
            var graphics = Graphics.FromImage(img);
            graphics.BeginContainer();
        }
    }
}
