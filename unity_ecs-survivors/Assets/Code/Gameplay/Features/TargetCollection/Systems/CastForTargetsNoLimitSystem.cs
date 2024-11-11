using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Physics;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
public class CastForTargetsNoLimitSystem : IExecuteSystem
{
    private readonly IPhysicsService _physicsService;
    private readonly IGroup<GameEntity> _ready;
    private readonly List<GameEntity> _buffer = new (64);

    public CastForTargetsNoLimitSystem(GameContext gameContext, IPhysicsService physicsService)
    {
        _physicsService = physicsService;
        _ready = gameContext.GetGroup(GameMatcher
                                      .AllOf(
                                          GameMatcher.ReadyToCollectTargets,
                                          GameMatcher.Radius,
                                          GameMatcher.TargetsBuffer,
                                          GameMatcher.WorldPosition,
                                          GameMatcher.LayerMask
                                      ).NoneOf(
                                          GameMatcher.TargetLimit
                                          ));
    }
    
    public void Execute()
    {
        foreach (var entity in _ready.GetEntities(_buffer))
        {
            entity.targetsBuffer.value.AddRange(TargetsInRadius(entity));

            if (!entity.isCollectingTargetsContinuously)
                entity.isReadyToCollectTargets = false;
        }
    }

    private IEnumerable<int> TargetsInRadius(GameEntity entity) =>
        _physicsService.CircleCast(entity.worldPosition.value, entity.radius.value, entity.layerMask.value)
                       .Select(x => x.id.id);
}
}