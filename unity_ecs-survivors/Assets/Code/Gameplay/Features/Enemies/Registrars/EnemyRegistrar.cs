using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registrars
{
public class EnemyRegistrar : EntityComponentRegistrar
{
    public float hp = 3;
    public float damage = 1;
    public float speed;

    public override void RegisterComponents()
    {
        Entity.AddWorldPosition(transform.position)
              .AddDirection(Vector2.zero)
              .AddSpeed(speed)
              .AddCurrentHP(hp)
              .AddMaxHP(hp)
              .AddDamage(damage)
              .AddTargetsBuffer(new List<int>(1))
              .AddRadius(0.3f)
              .AddCollectTargetsInterval(0.5f)
              .AddCollectTargetsTimer(0)
              .AddLayerMask(CollisionLayer.Hero.AsMask())
              .AddEnemyTypeId(EnemyTypeId.Goblin)
              .With(x => x.isEnemy = true)
              .With(x => x.isTurnAlongDirection = true);
    }

    public override void UnRegisterComponents()
    {
    }
}
}