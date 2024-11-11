using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
public class StaticDataService : IStaticDataService
{
    private Dictionary<AbilityID,AbilityConfig> _abilityById;

    public void LoadAll()
    {
        LoadAbilities();
    }

    public AbilityConfig GetAbilityConfig(AbilityID abilityID)
    {
        if (_abilityById.TryGetValue(abilityID, out var config))
            return config;

        throw new Exception($"Ability config for {abilityID} was not found");
    }

    public AbilityLevel GetAbilityLevel(AbilityID abilityID, int level)
    {
        var config = GetAbilityConfig(abilityID);
        if (level > config.levels.Count)
            level = config.levels.Count;

        return config.levels[level - 1];
    }
    
    private void LoadAbilities()
    {
        _abilityById = Resources.LoadAll<AbilityConfig>("Configs/Abilities")
                                .ToDictionary(x => x.abilityID, x => x);
    }
}
}