using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
  public class EnemyChaseHeroSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _enemies;
    private readonly IGroup<GameEntity> _heroes;

    public EnemyChaseHeroSystem(GameContext game)
    {
      _enemies = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Enemy,
          GameMatcher.WorldPosition));

      _heroes = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity hero in _heroes)
      foreach (GameEntity enemy in _enemies)
      {
        enemy.ReplaceDirection((hero.worldPosition.value - enemy.worldPosition.value).normalized);
        enemy.isMoving = true;
      }
    }
  }
}