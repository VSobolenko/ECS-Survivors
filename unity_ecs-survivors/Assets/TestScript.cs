using Entitas;
using UnityEngine;

namespace DefaultNamespace
{
public class Id : IComponent
{
    public int Value;
}

public class WorldPosition : IComponent
{
    public Vector3 Value;
}
class CheckImprovements
{
    public CheckImprovements()
    {
        GameEntity entity = null;
    }
}
}