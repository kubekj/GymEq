using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MASProjekt.Models
{
	public class Cleaning
	{
        [Key]
		public int ID { get; set; }

        [Required]
		public DateTime DoneAt { get; set; }

		public DateTime? EndedAt { get; set; }

        [Required]
		public string[] MaterialsUsed { get; set; }

        //Kompozycja
        [Required]
        [ForeignKey(nameof(MaidId))]
		public Maid Maid { get; set; }

        [Required]
        public int MaidId { get; set; }

    }
}

