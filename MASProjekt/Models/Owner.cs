using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MASProjekt.Models
{
	public class Owner : Employee
	{
		public Owner()
		{
			Agreements = new List<Agreement>();
		}

		public ICollection<Agreement> Agreements { get; set; }
	}
}

