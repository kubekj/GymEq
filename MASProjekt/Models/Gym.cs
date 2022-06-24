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

        public string Name { get; private set; } = "Zdrogit";

        [Required]
        [MaxLength(50)]
		public string Adress { get; set; }

        private readonly int _minGymAreas = 2; 

		public ICollection<Agreement> Agreements { get; set; }

        private ICollection<GymArea> gymAreas;
		public ICollection<GymArea> GymAreas
        {
            get { return gymAreas; }
            set
            {
                if (value.Count < _minGymAreas)
                    return;

                gymAreas = value;
            }
        }
    }
}

