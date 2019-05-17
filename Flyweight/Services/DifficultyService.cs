using Flyweight.Enums;
using System;
using System.Configuration;

namespace Flyweight.Services
{
    public static class DifficultyService
    {
        public static double GetDifficultyAsDouble()
        {
            Difficulty difficulty = (Difficulty)Convert.ToInt32(ConfigurationManager.AppSettings["Difficulty"]);
            double coeff = 0d;

            switch (difficulty)
            {
                case Difficulty.Easy:
                {
                    coeff = 0.7;
                    break;
                }
                case Difficulty.Medium:
                {
                    coeff = 0.55;
                    break;
                }
                case Difficulty.Hard:
                {
                    coeff = 0.45;
                    break;
                }
                case Difficulty.Imposible:
                {
                    coeff = 0.3;
                    break;
                }
                case Difficulty.Godlike:
                {
                    coeff = 0.1;
                    break;
                }
                default:
                {
                    throw new Exception("Something went wrong in GetDifficultyAsDouble()");
                }
            }

            return coeff;
        }
    }
}
