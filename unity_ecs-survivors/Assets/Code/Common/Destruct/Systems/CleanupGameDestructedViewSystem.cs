using System;
using Entitas;
using Object = UnityEngine.Object;

namespace Code.Common.Destruct.Systems
{
public class CleanupGameDestructedViewSystem : ICleanupSystem
{
    private readonly IGroup<GameEntity> _group;

    public CleanupGameDestructedViewSystem(GameContext gameContext)
    {
        _group = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Destructed, GameMatcher.View));
    }

    public void Cleanup()
    {
        foreach (GameEntity entity in _group)
        {
            entity.view.view.ReleaseEntity();
            Object.Destroy(entity.view.view.gameObject);
        }
    }
}
}