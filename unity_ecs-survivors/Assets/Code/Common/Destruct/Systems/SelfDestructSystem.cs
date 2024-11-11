using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Common.Destruct.Systems
{
public class SelfDestructSystem : IExecuteSystem
{
    private readonly ITimeService _timeService;
    private readonly IGroup<GameEntity> _group;
    private readonly List<GameEntity> _buffer = new(64);

    public SelfDestructSystem(GameContext gameContext, ITimeService timeService)
    {
        _timeService = timeService;
        _group = gameContext.GetGroup(GameMatcher.SelfDestructTimer);
    }
    
    public void Execute()
    {
        foreach (var entity in _group.GetEntities(_buffer))
        {
            if (entity.selfDestructTimer.time > 0)
            {
                entity.ReplaceSelfDestructTimer(entity.selfDestructTimer.time - _timeService.DeltaTime);
            }
            else
            {
                entity.RemoveSelfDestructTimer();
                entity.isDestructed = true;
            }
        }
    }
}
}