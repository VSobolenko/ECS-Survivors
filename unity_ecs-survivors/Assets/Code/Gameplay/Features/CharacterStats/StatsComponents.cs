using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.CharacterStats
{
[Game] public class BaseStats : IComponent { public Dictionary<Stats, float> value; }
[Game] public class StatModifiers : IComponent { public Dictionary<Stats, float> value; }
[Game] public class StatChanged : IComponent { public Stats value; }
}