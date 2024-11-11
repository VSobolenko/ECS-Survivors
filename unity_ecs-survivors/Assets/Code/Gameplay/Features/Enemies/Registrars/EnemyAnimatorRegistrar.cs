using Code.Gameplay.Features.Enemies.Behaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Enemies.Registrars
{
public class EnemyAnimatorRegistrar : EntityComponentRegistrar
{
    public EnemyAnimator enemyAnimator;

    public override void RegisterComponents()
    {
        Entity.AddEnemyAnimator(enemyAnimator)
              .AddDamageTakenAnimator(enemyAnimator);
    }

    public override void UnRegisterComponents()
    {
        if (Entity.hasEnemyAnimator)
            Entity.RemoveEnemyAnimator();
        
        if (Entity.hasDamageTakenAnimator)
            Entity.RemoveDamageTakenAnimator();
    }
}
}