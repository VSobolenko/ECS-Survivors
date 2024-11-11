﻿using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
public class FinalizeEnemyDeathProcessingSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(64);

    public FinalizeEnemyDeathProcessingSystem(GameContext game)
    {
        _entities = game.GetGroup(GameMatcher.AllOf(GameMatcher.AllOf(
                                                        GameMatcher.Enemy,
                                                        GameMatcher.Dead,
                                                        GameMatcher.ProcessingDeath)));
    }

    public void Execute()
    {
        foreach (GameEntity enemy in _entities.GetEntities(_buffer))
        {
            enemy.isProcessingDeath = false;
        }
    }
}
}