using Code.Gameplay.Common.Visuals;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Code.Gameplay.Common
{
[Game] public class Id : IComponent { [PrimaryEntityIndex] public int id; }
[Game] public class EntityLink : IComponent { [EntityIndex] public int value; }

[Game] public class WorldPosition : IComponent { public Vector3 value; }

[Game] public class Damage : IComponent { public float value; }
[Game] public class TransformComponent : IComponent { public Transform transform; }
[Game] public class SpriteRendererComponent : IComponent { public SpriteRenderer spriteRenderer; }
[Game] public class DamageTakenAnimatorComponent : IComponent { public IDamageTakenAnimator value; }
//[Game] public class StatusVisualComponent : IComponent { public IStatusVisuals value; }
}