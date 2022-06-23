using System;
using System.ComponentModel.DataAnnotations;

namespace MASProjekt.Models
{
	public abstract class Employee : Person
	{
		public int YearsOfExperience { get; set; }
		public float HoursOfWorkInCurrentMonth { get; set; }
	}
}

