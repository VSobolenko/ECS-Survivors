﻿using Code.Gameplay.Features.Effects.Factory;
using Entitas;

namespace Code.Gameplay.Features.EffectApplication.Systems
{
public class ApplyEffectsOnTargetsSystem : IExecuteSystem
{
    private readonly GameContext _game;
    private readonly IEffectFactory _effectFactory;
    private readonly IGroup<GameEntity> _entities;

    public ApplyEffectsOnTargetsSystem(GameContext game, IEffectFactory effectFactory)
    {
        _game = game;
        _effectFactory = effectFactory;
        _entities = game.GetGroup(GameMatcher
                                      .AllOf(
                                          GameMatcher.TargetBuffer,
                                          GameMatcher.EffectSetups));
    }

    public void Execute()
    {
        foreach (GameEntity entity in _entities)
        foreach (int targetId in entity.TargetBuffer)
        foreach (var setups in entity.effectSetups.value)
        {
            _effectFactory.CreateEffect(setups, ProducerID(entity), targetId);
        }
    }

    private int ProducerID(GameEntity entity)
    {
        return entity.hasProducerId ? entity.producerId.value : entity.id.id;
    }
}
}