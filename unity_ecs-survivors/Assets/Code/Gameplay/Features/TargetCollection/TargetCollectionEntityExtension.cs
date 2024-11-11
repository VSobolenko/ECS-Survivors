namespace Code.Gameplay.Features.TargetCollection
{
public static class TargetCollectionEntityExtension
{
    public static GameEntity RemoveTargetCollectionComponents(this GameEntity entity)
    {
        if (entity.hasEnemyAnimator)
            entity.RemoveEnemyAnimator();
        
        if (entity.hasDamageTakenAnimator)
            entity.RemoveDamageTakenAnimator();

        entity.isReadyToCollectTargets = false;

        return entity;
    }
}
}