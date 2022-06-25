using MASProjekt.Data;
using MASProjekt.Models;

namespace MASProjekt.Services
{
	public interface IExampleService
	{
		Task AddCleaning(int maidId, Cleaning cleaning);

		Task AddOpinion(int perosnalTrainingId, int gymMemberId,string opinion);

		Task<Activity> FindActivity(int clubMemberId ,string trainingTitle);
	}
}

