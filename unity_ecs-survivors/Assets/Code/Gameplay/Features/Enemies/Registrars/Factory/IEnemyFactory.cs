using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registrars.Factory
{
public interface IEnemyFactory
{
    GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 at);
}
}