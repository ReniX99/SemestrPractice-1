using System;
using back.DTOs.Exercise;
using back.Entities;
using back.Repositories;

namespace back.Services;

public class ExerciseService
{
    private readonly ExerciseRepository _exerciseRepository;
    private readonly ExerciseUserRepository _exerciseUserRepository;

    public ExerciseService(ExerciseRepository exerciseRepository, ExerciseUserRepository exerciseUserRepository)
    {
        _exerciseRepository = exerciseRepository;
        _exerciseUserRepository = exerciseUserRepository;
    }
    public async Task<int> Create(CreateExerciseDto createExerciseDto, int userId)
    {
        Exercise exerciseEntity = new Exercise
        {
            Title = createExerciseDto.Title,
            Date = createExerciseDto.Date,
            Priority = createExerciseDto.Priority,
            IsActive = createExerciseDto.IsActive
        };

        int exerciseId = await _exerciseRepository.Add(exerciseEntity);

        List<ExerciseUser> exerciseUserEntities = createExerciseDto.UserIds.Select(eu => new ExerciseUser
        {
            ExerciseId = exerciseId,
            UserId = eu,
        }).ToList();

        await _exerciseUserRepository.Add(exerciseUserEntities);

        return exerciseId;
    }

    public async Task<List<ExerciseDto>> GetAll(int userId)
    {
        List<ExerciseUser> exerciseUserEntities = await _exerciseUserRepository.Get(userId);

        return exerciseUserEntities.Select(eu => new ExerciseDto
        {
            Id = eu.Exercise.Id,
            Title = eu.Exercise.Title,
            Date = eu.Exercise.Date,
            Priority = eu.Exercise.Priority,
            IsActive = eu.Exercise.IsActive
        }).ToList();
    }
}
