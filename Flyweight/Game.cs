using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flyweight
{
    public class Game
    {
        private City _city;
        private RedisClient _redisClient;
        public void StartGame()
        {
            var cityName = UserIO.GetUserAnswer("Hello ElPrezedente!\nEnter your new city name:");
            _redisClient = new RedisClient("localhost");
            _city = _redisClient.Get<City>(cityName.ToLower());

            if (_city == null)
            {
                _city = new City(cityName);
                _city.ElPrezedenteName = UserIO.GetUserAnswer("How should i call you, my Prezedente");
            }

            while (_city != null)
            {
                Continue();
            }
        }

        private void Continue()
        {
            try
            {
                var controll = UserIO.GetUserControll();

                if (controll == ConsoleKey.A)
                {
                    int buildigAmount = Convert.ToInt32(UserIO.GetUserAnswer("How many building you want?"));

                    UserIO.SayToUser($"Available plans: ");
                    foreach (string plan in _city.GetPlansAsString())
                    {
                        UserIO.SayToUser(plan);
                    }

                    string planName = UserIO.GetUserAnswer("What building plan do you want to build?");

                    _city.AddBuildingsAmount(buildigAmount, planName);
                    return;
                }

                if (controll == ConsoleKey.S)
                {
                    foreach (string stat in _city.GetStats())
                    {
                        UserIO.SayToUser(stat);
                    }
                    UserIO.SayToUser(string.Empty);
                    return;
                }

                if (controll == ConsoleKey.F)
                {
                    Finish();
                    return;
                }

                if (controll == ConsoleKey.R)
                {
                    UserIO.SayToUser("Are you realy want tot restart?");
                    var answer = UserIO.GetUserYN();

                    if ((bool)answer)
                    {
                        Restart();
                    }
                    return;
                }

                if (controll == ConsoleKey.Q)
                {
                    Preview(PreviewType.Picture);
                    return;
                }

                if (controll == ConsoleKey.E)
                {
                    Preview(PreviewType.Schema);
                    return;
                }
                ElseCase();
            }
            catch (Exception ex)
            {
                UserIO.SayToUser("Incorrect input");
                return;
            }
        }

        private void Preview(PreviewType type)
        {
            var plansNameWIndexes = _city.GetPlansAsString();

            if (plansNameWIndexes == null || plansNameWIndexes.Count < 1)
            {
                UserIO.SayToUser("No available plans\n");
                return;
            }

            UserIO.SayToUser("Available plans");
            foreach (string name in plansNameWIndexes)
            {
                UserIO.SayToUser(name);
            }

            var key = UserIO.GetUserAnswer("Select plan index from list");
            var plan = _city.GetBuildingPlanFromFactoryByIndex(Convert.ToInt32(key));

            if (plan == null)
            {
                UserIO.SayToUser("Id not found, probably you are idiot.");
                return;
            }

            if (type == PreviewType.Picture)
            {
                plan.PreviewPlan();
            }

            if (type == PreviewType.Schema)
            {
                plan.LookOnSchema();
            }
        }

        private void DestroyCity()
        {
            _redisClient.Remove(_city.Name.ToLower());
            _city = null;
        }

        private void Finish()
        {
            UserIO.SayToUser("We will miss you <3");
            Environment.Exit(0);
        }

        private void Restart()
        {
            DestroyCity();
            StartGame();
        }

        private void ElseCase()
        {
            DestroyCity();
            UserIO.SayToUser("OMG you dumb fuck, your shit vilage destroyed HAVE FUN!");
            Environment.Exit(0);
        }
    }
}
