using System;
using MASProjekt.Models;

namespace MASProjekt.Services
{
	public interface ITrainerService
	{
        List<Trainer> Trainers { get; set; }

        Task LoadTrainers();

        Task<List<Trainer>> LoadFreeTrainers(int id);

        Task<Trainer> GetTrainer(int id);
    }
}

