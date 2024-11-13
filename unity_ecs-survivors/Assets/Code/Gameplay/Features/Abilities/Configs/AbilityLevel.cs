using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Infrastructure.View;

namespace Code.Gameplay.Features.Abilities.Configs
{
  [Serializable]
  public class AbilityLevel
  {
    public float Cooldown;

    public EntityBehaviour ViewPrefab;

    public List<EffectSetup> effectSetups;
    
    public ProjectileSetup ProjectileSetup;
  }
}