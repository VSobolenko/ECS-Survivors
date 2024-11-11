﻿using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
public class DirectionalDeltaMoveSystem : IExecuteSystem
{
    private readonly ITimeService _time;
    private readonly IGroup<GameEntity> _movers;

    public DirectionalDeltaMoveSystem(GameContext gameContext, ITimeService timeService)
    {
        _time = timeService;
        _movers = gameContext.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.WorldPosition,
                GameMatcher.Direction,
                GameMatcher.Moving,
                GameMatcher.Speed));
    }

    public void Execute()
    {
        foreach (var mover in _movers)
        {
            mover.ReplaceWorldPosition((Vector2)mover.worldPosition.value + mover.direction.value * mover.speed.value * _time.DeltaTime);
        }
    }
}
}