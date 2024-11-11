using System.Collections.Generic;
using Code.Gameplay.Common.Physics;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
public class CastForTargetsWithLimitSystem : IExecuteSystem, ITearDownSystem
{
    private readonly IPhysicsService _physicsService;
    private readonly IGroup<GameEntity> _ready;
    private readonly List<GameEntity> _buffer = new (64);
    private GameEntity[] _targetCastBuffer = new GameEntity[128];

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
            // entity.targetsBuffer.value.AddRange(TargetCountInRadius(entity));

            for (int i = 0; i < Mathf.Min(TargetCountInRadius(entity), entity.targetLimit.value); i++)
            {
                var targetId = _targetCastBuffer[i].id.id;
                
                if (!AlreadyProcess(entity, targetId))
                {
                    entity.targetsBuffer.value.Add(targetId);
                    entity.processedTargets.value.Add(targetId);
                }
            }
            if (!entity.isCollectingTargetsContinuously)
                entity.isReadyToCollectTargets = false;
        }
    }

    private bool AlreadyProcess(GameEntity entity, int targetId) => entity.processedTargets.value.Contains(targetId);

    private int TargetCountInRadius(GameEntity entity) =>
        _physicsService.CircleCastNonAlloc(entity.worldPosition.value, entity.radius.value, entity.layerMask.value,
                                           _targetCastBuffer);

    public void TearDown()
    {
        _targetCastBuffer = null;
    }
}   
}