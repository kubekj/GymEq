using System;
using System.ComponentModel.DataAnnotations;

namespace MASProjekt.Models
{
	public abstract class Person
	{
        public Person()
        {
            Agreements = new List<Agreement>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string? SecondName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public ICollection<Agreement> Agreements { get; set; }
    }
}

