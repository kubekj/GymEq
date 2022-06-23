using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MASProjekt.Models
{
	public class GymArea
	{
        [Key]
		public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
		public string[] Equipment { get; set; }

        //Kompozycja
        [Required]
        [ForeignKey(nameof(GymId))]
		private Gym Gym { get; set; }

        [Required]
        public int GymId { get; set; }
    }
}

