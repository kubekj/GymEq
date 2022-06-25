using System;
using MASProjekt.Data;
using MASProjekt.Models;

namespace MASProjekt.Services
{
	public class ExampleService : IExampleService
	{
        private readonly DataContext _context;

        public ExampleService(DataContext dataContext)
        {
            _context = dataContext;

        }

        #region Asocjacja kwalifikowana - znalezienie po nazwie
        public async Task<Activity> FindActivity(int clubMemberId, string activityTitle)
        {
            var clubMember = await _context.ClubMembers.FindAsync(clubMemberId);

            if (clubMember == null)
                throw new Exception("Cannot do that");

            var activity = clubMember.Activities.FirstOrDefault(x => x.Title == activityTitle);

            if (activity == null)
                throw new Exception("There is no activity of that title");

            return activity;
        }
        #endregion

        #region Przykład ograniczenia - subset
        public async Task AddOpinion(int personalTrainingId, int clubMemberId, string opinion)
        {
            var personalTraining = await _context.PersonalTrainings.FindAsync(personalTrainingId);

            if (personalTraining == null)
                throw new Exception("Cannot do that");

            if (personalTraining.ClubMemberId != clubMemberId)
                throw new Exception("Cannot add an opinion if you haven't taken part in it !");

            personalTraining.Opinion = opinion;

            await _context.SaveChangesAsync();
            
        }
        #endregion

        #region Przyklad kompozycji - sprzatanie
        public async Task AddCleaning(int maidId, Cleaning cleaning)
        {
            var maid = await _context.Maids.FindAsync(maidId);

            if (maid == null)
                throw new Exception("Cannot do that");

            maid.Cleanings.Add(cleaning);

            await _context.SaveChangesAsync();
        }
        #endregion
    }
}

