using System;
using Entitas;

namespace Code.Gameplay.Features.DamageApplication.Systems
{
public class ApplyDamageOnTargets : IExecuteSystem
{
    private readonly GameContext _gameContext;
    private readonly IGroup<GameEntity> _damageDealers;

    public ApplyDamageOnTargets(GameContext gameContext)
    {
        _gameContext = gameContext;
        _damageDealers = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.TargetsBuffer, GameMatcher.Damage));
    }

    public void Execute()
    {
        foreach (var damageDealer in _damageDealers)
        foreach (var targetsId in damageDealer.targetsBuffer.value)
        {
            var target = _gameContext.GetEntityWithId(targetsId);
            if (target.hasCurrentHP)
            {
                target.ReplaceCurrentHP(target.currentHP.value - damageDealer.damage.value);
                if (target.hasDamageTakenAnimator)
                    target.damageTakenAnimator.value.PlayDamageTaken();
            }
        }
    }
}
}