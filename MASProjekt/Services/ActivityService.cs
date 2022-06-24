using System;
using MASProjekt.Data;
using MASProjekt.Models;
using Microsoft.EntityFrameworkCore;

namespace MASProjekt.Services
{
	public class ActivityService : IActivityService
	{
		private readonly DataContext _context;

		public List<Activity> Activities { get; set; } = new List<Activity>();

        public ActivityService(DataContext dataContext)
		{
			_context = dataContext;
		}

		public async Task LoadActivities()
        {
			Activities = await _context.Activities.ToListAsync();
        }

        public async Task<Activity> GetActivity(int id)
        {
            var activity = await _context.Activities.FindAsync(id);

            if (activity == null)
                throw new Exception("No activity found");

            return activity;
        }

        public async Task AssignTrainer(int trainerID, int activityID)
        {
			var dbActivity = await _context.Activities.FindAsync(activityID);

            if (dbActivity == null)
                throw new Exception("Activity doesn't exists");

            var trainer = await _context.Trainers.FindAsync(trainerID);

            if (trainer == null)
                throw new Exception("Trainer with that ID doesn't exists");

			dbActivity.TrainerId = trainerID;

            await _context.SaveChangesAsync();
        }

        public async Task PostponeActivity(DateTime newTime, int id)
        {
            var dbActivity = await _context.Activities.FindAsync(id);

            if (dbActivity == null)
                throw new Exception("Activity doesn't exists.");

            var activityAtThatTime = await _context.Activities.FirstOrDefaultAsync(x => x.Start.Date == newTime.Date && x.Start.Hour == newTime.Hour);

            if (activityAtThatTime != null)
                throw new Exception("Activity at that time already exists! You can try again or just remove the activity.");

            if (newTime.Date <= DateTime.UtcNow.Date)
                throw new Exception("New start time cannot be in the past.");

            dbActivity.Start = newTime;
            dbActivity.End = newTime.AddHours(1);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveActivity(int id)
        {
            var dbActivity = await _context.Activities.FindAsync(id);

            if (dbActivity == null)
                throw new Exception("Activity doesn't exists");

            _context.Activities.Remove(dbActivity);

            await _context.SaveChangesAsync();
        }
    }
}

