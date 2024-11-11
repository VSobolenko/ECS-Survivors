using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
public class HeroDeathSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public HeroDeathSystem(GameContext game)
    {
        _entities = game.GetGroup(GameMatcher
                                      .AllOf(GameMatcher.AllOf(
                                                 GameMatcher.Hero,
                                                 GameMatcher.Dead,
                                                 GameMatcher.HeroAnimator,
                                                 GameMatcher.ProcessingDeath
                                             )));
    }

    public void Execute()
    {
        foreach (GameEntity hero in _entities)
        {
            hero.isMovementAvailable = false;
            hero.isTurnAlongDirection = false;
            hero.heroAnimator.heroAnimator.PlayDied();
        }
    }
}
}