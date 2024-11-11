using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{

[CreateAssetMenu(menuName = "ECS Survivors", fileName = "AbilityConfig")]
public class AbilityConfig : ScriptableObject
{
    public AbilityID abilityID;
    public List<AbilityLevel> levels;
}
}