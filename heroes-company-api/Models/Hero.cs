using System;
using System.ComponentModel.DataAnnotations;

namespace heroes_company_api.Models
{
    public class Hero
    {
        public Guid Id { get; set; }

        public string TrainerId { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ability is Required")]
        [RegularExpression("^(Attacker|Defender)$", ErrorMessage = "Please choose Attacker or Defender")]
        public string Ability { get; set; }

        [Required(ErrorMessage = "Suit Colors are Required")]
        public string SuitColors { get; set; }

        public DateTime DateStartedTraining { get; set; }

        [Required(ErrorMessage = "Starting Power is Required")]
        public decimal StartingPower { get; set; }

        public decimal CurrentPower { get; set; }

        public string ImgUrl { get; set; }

        public int DailyTrainingsCounter { get; set; }

        public DateTime LastTrainingDate { get; set; }

        public Hero()
        {

        }

        public Hero(string trainerId, string name, string ability, string suitColors, decimal startingPower)
        {
            Id = new Guid();
            TrainerId = trainerId;
            Name = name;
            Ability = ability;
            SuitColors = suitColors;
            DateStartedTraining = DateTime.Now.Date;
            StartingPower = startingPower;
            CurrentPower = startingPower;
            DailyTrainingsCounter = 0;
            LastTrainingDate = DateTime.Now.Date;

            int randomNum = new Random().Next(1, 1000);
            ImgUrl = ($"https://robohash.org/{randomNum}?set=set2");
        }

        public decimal Train()
        {
            decimal lastPowerLevel = CurrentPower;
            DateTime today = DateTime.Now.Date;
            if (today.Equals(LastTrainingDate))
            {
                if (DailyTrainingsCounter < 5)
                {
                    CurrentPower *= new Random().Next(100, 110) * (decimal)0.01;
                    DailyTrainingsCounter++;
                    return CurrentPower - lastPowerLevel;
                }
                else
                    return -1;
            }
            else
            {
                LastTrainingDate = today;
                DailyTrainingsCounter = 1;
                CurrentPower *= new Random().Next(100, 110) * (decimal)0.01;
                return CurrentPower - lastPowerLevel;
            }
        }
    }
}
