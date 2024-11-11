﻿using Code.Gameplay.Features.TargetCollection.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.TargetCollection
{
public class CollectTargetsFeature : Feature
{
    public CollectTargetsFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<CollectTargetIntervalSystems>());
        Add(systemFactory.Create<CastForTargetsNoLimitSystem>());
        Add(systemFactory.Create<CastForTargetsWithLimitSystem>());
        Add(systemFactory.Create<CleanupTargetBuffersSystem>());
    }
}
}