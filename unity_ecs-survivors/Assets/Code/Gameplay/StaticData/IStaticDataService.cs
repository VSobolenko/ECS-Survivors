﻿using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;

namespace Code.Gameplay.StaticData
{
  public interface IStaticDataService
  {
      void LoadAll();
      AbilityConfig GetAbilityConfig(AbilityID abilityID);
      AbilityLevel GetAbilityLevel(AbilityID abilityID, int level);
  }
}