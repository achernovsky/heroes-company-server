using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace heroes_company_api.Dtos
{
    public class HeroDto
    {
        public Guid Id { get; set; }

        //public string TrainerId { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ability is Required")]
        [RegularExpression("^(Attacker|Defender)$", ErrorMessage = "Please choose Attacker or Defender")]
        public string Ability { get; set; }

        [Required(ErrorMessage = "Suit Colors are Required")]
        public string SuitColors { get; set; }

        public DateTime DateStartedTraining { get; set; }

        //[Required(ErrorMessage = "Starting Power is Required")]
        public decimal StartingPower { get; set; }

        public decimal CurrentPower { get; set; }

        public string ImgUrl { get; set; }

        //public int DailyTrainingsCounter { get; set; }

        //public DateTime LastTrainingDate { get; set; }

/*        public HeroDto(string trainerId, string name, string ability, string suitColors, decimal startingPower)
        {
            Id = new Guid();
            TrainerId = trainerId;
            Name = name;
            Ability = ability;
            SuitColors = suitColors;
            StartedTraining = DateTime.Now.Date;
            StartingPower = startingPower;
            CurrentPower = startingPower;
            dailyTrainingsCounter = 0;
            trainingSessionStarted = DateTime.Now.Date;

            int randomNum = new Random().Next(1, 1000);
            ImgUrl = ($"https://robohash.org/{randomNum}?set=set2");
        }*/

/*        public string train()
        {
            DateTime today = DateTime.Now.Date;
            if (today.Equals(trainingSessionStarted))
            {
                if (dailyTrainingsCounter < 5)
                {
                    CurrentPower *= new Random().Next(100, 110) * (decimal)0.01;
                    dailyTrainingsCounter++;
                    return "Training completed, new power is " + CurrentPower;
                }
                else
                {
                    return "This hero already reched his daily training limit";
                }
            }
            else
            {
                trainingSessionStarted = today;
                dailyTrainingsCounter = 1;
                CurrentPower *= new Random().Next(100, 110) * (decimal)0.01;
                return "Training completed, new power is " + CurrentPower;
            }
        }*/
    }
}
