using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MASProjekt.Models
{
	public class GymArea
	{
        private GymArea() { }

        private GymArea(int id,Gym gym,string name, string[] equipment)
        {
            ID = id;
            Gym = gym;
            Name = name;
            Equipment = equipment;
        }

        public static GymArea Create(int id, Gym gym, string name, string[] equipment)
        {
            if (gym == null)
                throw new Exception("Strefa silowni nie moze powstac bez silowni");

            GymArea gymArea = new GymArea(id, gym, name, equipment);

            return gymArea;
        }

        [Key]
		public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
		public string[] Equipment { get; set; }

        //Kompozycja
        [Required]
        [ForeignKey(nameof(GymId))]
		public Gym Gym { get; set; }

        [Required]
        public int GymId { get; set; }
    }
}

