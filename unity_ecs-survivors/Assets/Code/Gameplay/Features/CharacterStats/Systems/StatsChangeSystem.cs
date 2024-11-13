using Entitas;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
public class StatsChangeSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _statsChanges;
    private readonly IGroup<GameEntity> _statOwners;

    public StatsChangeSystem(GameContext game)
    {
        _statsChanges = game.GetGroup(GameMatcher.AllOf(new[]
        {
            GameMatcher.StatChanged,
            GameMatcher.TargetId,
            GameMatcher.EffectValue,
        }));

        _statOwners = game.GetGroup(GameMatcher.AllOf(new[]
        {
            GameMatcher.Id,
            GameMatcher.BaseStats,
            GameMatcher.StatModifiers,
        }));
    }

    public void Execute()
    {
        foreach (GameEntity statOwner in _statOwners)
        foreach (var stat in statOwner.baseStats.value.Keys)
        {
            statOwner.statModifiers.value[stat] = 0;
            foreach (var statsChange in _statsChanges)
            {
                if (statsChange.targetId.value == statOwner.id.id)
                    statOwner.statModifiers.value[stat] += statsChange.effectValue.value;
            }
        }
    }
}
}