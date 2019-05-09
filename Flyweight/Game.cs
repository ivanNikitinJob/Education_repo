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
            var cityName = UserIO.GetUserAnswer("Hello ElPrezedente!\nEnter your new city name:\n");
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
            var controll = UserIO.GetUserControll();

            if (controll == ConsoleKey.A)
            {
                int buildigAmount = Convert.ToInt32(UserIO.GetUserAnswer("How many building you want?"));
                string planName = UserIO.GetUserAnswer("What building do you want to build?");
                _city.AddBuildingsAmount(buildigAmount, planName);
                return;
            }

            if (controll == ConsoleKey.S)
            {
                foreach (string stat in _city.GetStats())
                {
                    UserIO.SayToUser(stat);
                }
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

        private void Preview(PreviewType type)
        {
            UserIO.SayToUser("Available plans");
            var plansNameWIndexes = _city.GetPlansAsString();

            foreach (string name in plansNameWIndexes)
            {
                UserIO.SayToUser(name);
            }

            var key = UserIO.GetUserAnswer("Select plan index from list");
            var plan = _city.GetBuildingPlanFromFactoryByIndex(Convert.ToInt32(key));

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
