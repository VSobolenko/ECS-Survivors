using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Abilities.Factory
{
public class AbilityFactory : IAbilityFactory
{
    private readonly IIdentifierService _identifierService;
    private readonly IStaticDataService _staticDataService;

    public AbilityFactory(IIdentifierService identifierService, IStaticDataService staticDataService)
    {
        _identifierService = identifierService;
        _staticDataService = staticDataService;
    }

    public GameEntity CreateVegetableBoltAbility(int level)
    {
        var abilityLevel = _staticDataService.GetAbilityLevel(AbilityID.VegetableBolt, level);

        return CreateEntity.Empty()
                           .AddId(_identifierService.Next())
                           .AddAbilityID(AbilityID.VegetableBolt)
                           .AddCooldown(abilityLevel.cooldown)
                           .With(x => x.isVegetableBoltAbility = true)
                           .PutOnCooldown();
    }
}
}