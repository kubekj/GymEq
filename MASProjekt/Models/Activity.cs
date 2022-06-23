using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MASProjekt.Data;

namespace MASProjekt.Models
{
	public class Activity
	{
        public Activity()
        {
			ClubMembers = new List<ClubMember>();
        }

        [Key]
		public int ID { get; set; }

        [Required]
		public string Title { get; set; }

		private static readonly int _minimalAtendeesCount = 5;
		private static readonly int _maximalAtendeesCount = 25;

        [Required]
        [MaxLength(200)]
		public string Description { get; set; }

        [Required]
		public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [ForeignKey(nameof(TrainerId))]
        public Trainer? Trainer { get; set; }

		public int? TrainerId { get; set; }

		public ICollection<ClubMember> ClubMembers { get; set; }
    }
}

