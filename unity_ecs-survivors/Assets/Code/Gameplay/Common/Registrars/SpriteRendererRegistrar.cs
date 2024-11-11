using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Common.Registrars
{
public class SpriteRendererRegistrar : EntityComponentRegistrar
{
    public SpriteRenderer spriteRenderer;

    public override void RegisterComponents() => Entity.AddSpriteRenderer(spriteRenderer);

    public override void UnRegisterComponents()
    {
        if (Entity.hasSpriteRenderer)
            Entity.RemoveSpriteRenderer();
    }
}
}