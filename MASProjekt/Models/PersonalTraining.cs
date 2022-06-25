using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MASProjekt.Data;

namespace MASProjekt.Models
{
	public class PersonalTraining
	{
        [Key]
		public int ID { get; set; }

        [Required]
		public TrainingType TrainingType { get; set; }

		private static readonly int _maxTrainingDuration = 90;

        private int duration;
        [Required]
		public int Duration
        {
            get { return duration; }
            set
            {
                if (value > _maxTrainingDuration || value <= 0)
                    return;

                duration = value;
            }
        }

        [MaxLength(300)]
		public string? Opinion { get; set; }

        [ForeignKey(nameof(ClubMemberId))]
		public ClubMember ClubMember { get; set; }

        [ForeignKey(nameof(TrainerId))]
        public Trainer Trainer { get; set; }

		public int ClubMemberId { get; set; }
        public int TrainerId { get; set; }
    }
}

