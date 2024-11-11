using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
public class RotateAlongDirectionSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public RotateAlongDirectionSystem(GameContext game)
    {
        _entities = game.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.Direction,
                GameMatcher.Transform,
                GameMatcher.RotationAlignedAlongDirection
            ));
    }

    public void Execute()
    {
        foreach (var entity in _entities)
        {
            if (entity.direction.value.sqrMagnitude >= 0.01f)
            {
                var angle = Mathf.Atan2(entity.direction.value.y, entity.direction.value.x) * Mathf.Rad2Deg;
                entity.transform.transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }

    private float FaceDirection(GameEntity mover) => mover.direction.value.x <= 0 ? -1 : 1;
}
}