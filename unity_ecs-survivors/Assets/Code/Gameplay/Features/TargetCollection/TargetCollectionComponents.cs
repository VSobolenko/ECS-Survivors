using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection
{
[Game] public class ReadyToCollectTargets : IComponent { }
[Game] public class CollectingTargetsContinuously : IComponent { }
[Game] public class TargetsBuffer : IComponent { public List<int> value; }
[Game] public class ProcessedTargets : IComponent { public List<int> value; }
[Game] public class CollectTargetsInterval : IComponent { public float value; }
[Game] public class CollectTargetsTimer : IComponent { public float value; }
[Game] public class RadiusComponent : IComponent { public float value; }
[Game] public class LayerMaskComponent : IComponent { public int value; }
}