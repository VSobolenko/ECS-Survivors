using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
public class ArmamentFactory : IArmamentFactory
{
    private readonly IIdentifierService _identifierService;
    private readonly IStaticDataService _staticDataService;

    public ArmamentFactory(IIdentifierService identifierService, IStaticDataService staticDataService)
    {
        _identifierService = identifierService;
        _staticDataService = staticDataService;
    }

    public GameEntity CreateVegetableBolt(int level, Vector3 at)
    {
        var abilityLevel = _staticDataService.GetAbilityLevel(AbilityID.VegetableBolt, level);
        var setup = abilityLevel.projectileSetup;

        return CreateEntity.Empty()
                           .AddId(_identifierService.Next())
                           .AddWorldPosition(at)
                           .AddViewPrefab(abilityLevel.viewPrefab)
                           .AddSpeed(setup.speed)
                           .AddDamage(1)
                           .AddRadius(setup.contactRadius)
                           .AddTargetsBuffer(new List<int>(16))
                           .AddLayerMask(CollisionLayer.Enemy.AsMask())
                           .AddTargetLimit(setup.pierce)
                           .With(x => x.isArmament = true)
                           .With(x => x.isMovementAvailable = true)
                           .With(x => x.isReadyToCollectTargets = true)
                           .With(x => x.isCollectingTargetsContinuously = true)
                           .AddSelfDestructTimer(setup.lifeTime)
            ;
    }
}
}