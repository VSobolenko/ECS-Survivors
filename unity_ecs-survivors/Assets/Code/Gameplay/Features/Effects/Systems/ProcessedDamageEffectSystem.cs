using Entitas;

namespace Code.Gameplay.Features.Effects.Systems
{
public class ProcessedDamageEffectSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _effects;

    public ProcessedDamageEffectSystem(GameContext game)
    {
        _effects = game.GetGroup(GameMatcher.AllOf(
                                     GameMatcher.DamageEffect,
                                     GameMatcher.EffectValue,
                                     GameMatcher.TargetId
                                 ));
    }

    public void Execute()
    {
        foreach (var effect in _effects)
        {
            var target = effect.Target();
            effect.isProcessed = true;

            if (target.isDead)
                continue;

            target.ReplaceCurrentHp(target.CurrentHp - effect.effectValue.value);

            if (target.hasDamageTakenAnimator)
            {
                target.damageTakenAnimator.value.PlayDamageTaken();
            }
        }
    }
}
}