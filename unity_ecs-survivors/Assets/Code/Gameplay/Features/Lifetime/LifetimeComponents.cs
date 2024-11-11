using System;
using Entitas;

namespace Code.Gameplay.Features.Lifetime
{
[Game] public class MaxHP : IComponent { public float value; }

[Game] public class CurrentHP : IComponent { public float value; }
[Game] public class Dead : IComponent { }
[Game] public class ProcessingDeath : IComponent { }
}