using Entitas;

namespace Code.Gameplay.Features.Cooldowns
{
[Game] public class Cooldown : IComponent { public float value; }
[Game] public class CooldownLeft : IComponent { public float value; }
[Game] public class CooldownUp : IComponent { }
}