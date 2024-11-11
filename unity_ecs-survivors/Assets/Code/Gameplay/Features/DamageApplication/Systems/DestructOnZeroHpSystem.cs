using Entitas;

namespace Code.Gameplay.Features.DamageApplication.Systems
{
public class DestructOnZeroHpSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public DestructOnZeroHpSystem(GameContext gameContext)
    {
        _entities = gameContext.GetGroup(GameMatcher.CurrentHP);
    }
    
    public void Execute()
    {
        foreach (var entity in _entities)
        {
            if (entity.currentHP.value <= 0)
            {
                entity.isDestructed = true;
            }
        }
    }
}
}