using System;

namespace MASProjekt.Models
{
	public class Maid : Employee
	{
        public Maid()
        {
            Cleanings = new List<Cleaning>();
        }

        public ICollection<Cleaning> Cleanings { get; set; }
    }
}

