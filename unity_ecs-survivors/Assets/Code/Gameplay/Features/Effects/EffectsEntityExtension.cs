namespace Code.Gameplay.Features.Effects
{
public static class EffectsEntityExtension
{
    public static GameContext GameContext => Contexts.sharedInstance.game;

    public static GameEntity Producer(this GameEntity effect) =>
        effect.hasProducerId ? GameContext.GetEntityWithId(effect.producerId.value) : null;

    public static GameEntity Target(this GameEntity effect) =>
        effect.hasTargetId ? GameContext.GetEntityWithId(effect.targetId.value) : null;
}
}