using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
  public class HeroFactory : IHeroFactory
  {
      private readonly IIdentifierService _identifiers;

    public HeroFactory(IIdentifierService identifiers)
    {
      _identifiers = identifiers;
    }

    public GameEntity CreateHero(Vector3 at)
    {
        var baseStats = InitStats.EmptyStatsDictionary()
                                 .With(x => x[Stats.Speed] = 1)
                                 .With(x => x[Stats.MaxHp] = 3)
                                 .With(x => x[Stats.Damage] = 1)
            ;
      return CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .AddWorldPosition(at)
        .AddBaseStats(baseStats)
        .AddStatModifiers(InitStats.EmptyStatsDictionary())
        .AddDirection(Vector2.zero)
        .AddSpeed(baseStats[Stats.Speed])
        .AddCurrentHp(baseStats[Stats.MaxHp])
        .AddMaxHp(baseStats[Stats.MaxHp])
        .AddViewPath("Gameplay/Hero/hero")
        .With(x => x.isHero = true)
        .With(x => x.isTurnedAlongDirection = true)
        .With(x => x.isMovementAvailable = true);
    }

  }
}