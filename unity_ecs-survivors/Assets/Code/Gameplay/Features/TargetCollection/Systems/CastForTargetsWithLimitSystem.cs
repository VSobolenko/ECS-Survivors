using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Physics;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
public class CastForTargetsWithLimitSystem : IExecuteSystem, ITearDownSystem
{
    private readonly IPhysicsService _physicsService;
    private readonly IGroup<GameEntity> _ready;
    private readonly List<GameEntity> _buffer = new (64);
    private readonly GameEntity[] _targetCastBuffer = new GameEntity[128];

    public CastForTargetsWithLimitSystem(GameContext gameContext, IPhysicsService physicsService)
    {
        _physicsService = physicsService;
        _ready = gameContext.GetGroup(GameMatcher.AllOf(
                                          GameMatcher.ReadyToCollectTargets,
                                          GameMatcher.Radius,
                                          GameMatcher.TargetsBuffer,
                                          GameMatcher.TargetsBuffer,
                                          GameMatcher.ProcessedTargets,
                                          GameMatcher.TargetLimit,
                                          GameMatcher.WorldPosition,
                                          GameMatcher.LayerMask
                                      ));
    }
    
    public void Execute()
    {
        foreach (var entity in _ready.GetEntities(_buffer))
        {
            entity.targetsBuffer.value.AddRange(TargetCountInRadius(entity));

            if (!entity.isCollectingTargetsContinuously)
                entity.isReadyToCollectTargets = false;
        }
    }

    private int TargetCountInRadius(GameEntity entity) =>
        _physicsService.CircleCastNonAlloc(entity.worldPosition.value, entity.radius.value, entity.layerMask.value,
                                           _targetCastBuffer);

    public void TearDown()
    {
        _targetCastBuffer = null;
    }
}   
}