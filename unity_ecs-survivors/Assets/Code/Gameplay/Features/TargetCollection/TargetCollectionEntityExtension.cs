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

        if (entity.hasCollectTargetsTimer)
            entity.RemoveCollectTargetsTimer();
        
        entity.isReadyToCollectTargets = false;

        return entity;
    }
}
}