using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
public class HeroFactory : IHeroFactory
{
    private readonly IIdentifierService _identifierService;
    private const float HeroHP = 100;

    public HeroFactory(IIdentifierService identifierService)
    {
        _identifierService = identifierService;
    }

    public GameEntity CreateHero(Vector3 at)
    {
        return CreateEntity.Empty()
                    .AddId(_identifierService.Next())
                    .AddWorldPosition(at)
                    .AddDirection(Vector2.zero)
                    .AddSpeed(3)
                    .AddCurrentHP(HeroHP)
                    .AddMaxHP(HeroHP)
                    .AddViewPath("Gameplay/Hero/hero")
                    .With(x => x.isHero = true)
                    .With(x => x.isTurnAlongDirection = true)
                    .With(x => x.isMovementAvailable = true)
            ;
    }
}
}