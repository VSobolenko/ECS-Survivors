using Entitas;

namespace Code.Gameplay.Features.Effects
{
[Game] public class Effect : IComponent { }
[Game] public class ProducerId : IComponent { public int value; }
[Game] public class TargetId : IComponent { public int value; }
[Game] public class EffectValue : IComponent { public float value; }
[Game] public class DamageEffect : IComponent { }
}