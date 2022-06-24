using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MASProjekt.Models
{
	public class Trainer : Employee
	{
        public Trainer()
        {
            PersonalTrainings = new List<PersonalTraining>();
            Activities = new List<Activity>();
        }

		private static readonly float _agreementDiscount = 0.25f;

        public ICollection<PersonalTraining> PersonalTrainings { get; set; }
		public ICollection<Activity> Activities { get; set; }
    }
}

