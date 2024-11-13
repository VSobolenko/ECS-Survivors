using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Effects.Systems
{
public class CleanupProcessedEffect : ICleanupSystem
{
    private readonly IGroup<GameEntity> _group;
    private readonly List<GameEntity> _buffer = new(32);

    public CleanupProcessedEffect(GameContext game)
    {
        _group = game.GetGroup(GameMatcher.AllOf(GameMatcher.Effect, GameMatcher.Processed));
    }

    public void Cleanup()
    {
        foreach (GameEntity effect in _group.GetEntities(_buffer))
        {
            effect.Destroy();
        }
    }
}
}