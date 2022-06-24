using System;
using MASProjekt.Models;

namespace MASProjekt.Services
{
	public interface IActivityService
	{
		List <Activity> Activities { get; set; }

		Task LoadActivities();

		Task<Activity> GetActivity(int id);

		Task AssignTrainer(int trainerID, int activityID);

		Task PostponeActivity(DateTime newTime, int id);

		Task RemoveActivity(int id);
	}
}

