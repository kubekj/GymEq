﻿using System;
using MASProjekt.Data;
using MASProjekt.Models;
using Microsoft.EntityFrameworkCore;

namespace MASProjekt.Services
{
	public class TrainerService : ITrainerService
	{
        private readonly DataContext _context;

        public List<Trainer> Trainers { get; set; } = new List<Trainer>();

        public TrainerService(DataContext dataContext)
		{
            _context = dataContext;
		}

        public async Task LoadTrainers()
        {
            Trainers = await _context.Trainers.ToListAsync();
        }

        public async Task<List<Trainer>> LoadFreeTrainers(int id)
        {
            var activity = await _context.Activities.FindAsync(id);

            //trenerzy ktorzy nie maja w trakcie wskazanych zajęc akurat przypisanych zajęc

            var trainers = await _context.Activities.Select(x => x.Trainer).Where(x => x.Activities.Any(x => x.Start.Date != activity.Start.Date) || !x.Activities.Any()).ToListAsync();

            return trainers;
        } 

        public async Task<Trainer> GetTrainer(int? id)
        {
            var trainer = await _context.Trainers.FindAsync(id);

            if (trainer == null)
                throw new Exception("No trainer found");

            return trainer;
        }
    }
}

