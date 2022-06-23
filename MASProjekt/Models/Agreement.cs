using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MASProjekt.Models
{
	public class Agreement
	{
        [Required]
        public DateTime SignUpDate { get; set; }

		public DateTime? ResignationDate { get; set; }

        [Required]
		public AgreementType AgreementType { get; set; }

        [ForeignKey(nameof(IdGym))]
		public Gym Gym { get; set; }

        [ForeignKey(nameof(IdPerson))]
		public Person Person { get; set; }

        [Required]
        public int IdGym { get; set; }

        [Required]
        public int IdPerson { get; set; }
    }
}

