using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Registrars
{
public class HeroRegistrar : EntityComponentRegistrar
{
    public float maxHP = 100;
    public float speed;

    public override void RegisterComponents()
    {
        Entity
            .AddWorldPosition(transform.position)
            .AddDirection(Vector2.zero)
            .AddSpeed(speed)
            .AddCurrentHP(maxHP)
            .AddMaxHP(maxHP)
            .With(x => x.isHero = true)
            .With(x => x.isTurnAlongDirection = true)
            ;
    }

    public override void UnRegisterComponents()
    {
    }
}
}