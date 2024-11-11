﻿using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Armaments.Systems
{
public class FinalizeProcessedArmamentSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _armaments;

    public FinalizeProcessedArmamentSystem(GameContext game)
    {
        _armaments = game.GetGroup(GameMatcher.AllOf(
                                                         GameMatcher.Armament, 
                                                         GameMatcher.Processed
                                                     ));
    }

    public void Execute()
    {
        foreach (GameEntity aramment in _armaments)
        {
            aramment.RemoveTargetCollectionComponents();
            aramment.isDestructed = true;
        }
    }
}
}