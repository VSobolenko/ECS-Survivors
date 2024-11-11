using Code.Common.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
public class TurnAlongDirectionSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _movers;

    public TurnAlongDirectionSystem(GameContext game)
    {
        _movers = game.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.TurnAlongDirection,
                GameMatcher.SpriteRenderer,
                GameMatcher.Direction
            ));
    }

    public void Execute()
    {
        foreach (var mover in _movers)
        {
            var scale = Mathf.Abs(mover.transform.transform.localScale.x);
            mover.spriteRenderer.spriteRenderer.transform.SetScaleX(scale * FaceDirection(mover));
        }
    }

    private float FaceDirection(GameEntity mover) => mover.direction.value.x <= 0 ? -1 : 1;
}
}