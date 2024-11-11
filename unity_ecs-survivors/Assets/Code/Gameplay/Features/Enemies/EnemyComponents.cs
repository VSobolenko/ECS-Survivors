using Code.Gameplay.Features.Enemies.Behaviours;
using Entitas;

namespace Code.Gameplay.Features.Enemies
{
[Game] public class Enemy : IComponent { }
[Game] public class EnemyAnimatorComponent : IComponent { public EnemyAnimator animator; }
[Game] public class SpawnTimerComponent : IComponent { public float value; }
[Game] public class EnemyTypeIdComponent : IComponent { public EnemyTypeId typeId; }
}