using Entitas;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
public class ApplySpeedFromStatsSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _statOwners;

    public ApplySpeedFromStatsSystem(GameContext game)
    {
        _statOwners = game.GetGroup(GameMatcher.AllOf(new[]
        {
            GameMatcher.StatModifiers,
            GameMatcher.BaseStats,
            GameMatcher.Speed,
        }));
    }

    public void Execute()
    {
        foreach (GameEntity entity in _statOwners)
        {
            
        }
    }
}
}