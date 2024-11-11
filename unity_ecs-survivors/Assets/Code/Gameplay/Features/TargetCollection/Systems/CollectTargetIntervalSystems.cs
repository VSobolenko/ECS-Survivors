using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
public class CollectTargetIntervalSystems : IExecuteSystem
{
    private readonly ITimeService _timeService;
    private readonly IGroup<GameEntity> _entities;

    public CollectTargetIntervalSystems(GameContext gameContext, ITimeService timeService)
    {
        _timeService = timeService;
        _entities = gameContext.GetGroup(GameMatcher.AllOf(
                                             GameMatcher.TargetsBuffer,
                                             GameMatcher.CollectTargetsInterval,
                                             GameMatcher.CollectTargetsTimer));
    }
    
    public void Execute()
    {
        foreach (var entity in _entities)
        {
            entity.ReplaceCollectTargetsTimer(entity.collectTargetsTimer.value - _timeService.DeltaTime);
            if (entity.collectTargetsTimer.value <= 0)
            {
                entity.isReadyToCollectTargets = true;
                entity.ReplaceCollectTargetsTimer(entity.collectTargetsInterval.value);
            }
        }
    }
}
}