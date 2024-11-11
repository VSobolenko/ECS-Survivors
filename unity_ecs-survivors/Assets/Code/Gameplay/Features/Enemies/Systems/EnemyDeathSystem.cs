using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
public class EnemyDeathSystem : IExecuteSystem
{
    private const float DeathAnimationTime = 2;
    private readonly IGroup<GameEntity> _entities;

    public EnemyDeathSystem(GameContext game)
    {
        _entities = game.GetGroup(GameMatcher.AllOf(GameMatcher
                                                        .AllOf(GameMatcher.Enemy,
                                                               GameMatcher.Dead,
                                                               GameMatcher.ProcessingDeath
                                                        )));
    }

    public void Execute()
    {
        foreach (GameEntity enemy in _entities)
        {
            enemy.isMovementAvailable = false;
            enemy.isTurnAlongDirection = false;
            enemy.RemoveTargetCollectionComponents();
            if (enemy.hasEnemyAnimator)
                enemy.enemyAnimator.animator.PlayDied();
            enemy.ReplaceSelfDestructTimer(DeathAnimationTime);
        }
    }
}
}