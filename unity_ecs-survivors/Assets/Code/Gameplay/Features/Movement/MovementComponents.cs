using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
public class MovementComponents
{
    [Game] public class Speed : IComponent { public float value; }
    [Game] public class Direction : IComponent { public Vector2 value; }
    [Game] public class Moving : IComponent {  }
    [Game] public class MovementAvailable : IComponent {  }
    [Game] public class TurnAlongDirection : IComponent {  }
}
}