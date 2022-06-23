using System;
using System.ComponentModel.DataAnnotations;

namespace MASProjekt.Models
{
	public class Gym
	{
        public Gym()
        {
			Agreements = new List<Agreement>();
			GymAreas = new List<GymArea>();
        }

        [Key]
		public int ID { get; set; }

        public string Name { get; set; } = "Zdrogit";

        [Required]
        [MaxLength(50)]
		public string Adress { get; set; }

		public ICollection<Agreement> Agreements { get; set; }
		public ICollection<GymArea> GymAreas { get; set; }
    }
}

