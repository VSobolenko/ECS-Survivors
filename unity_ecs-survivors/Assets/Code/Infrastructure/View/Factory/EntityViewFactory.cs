﻿using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View.Factory
{
public class EntityViewFactory : IEntityViewFactory
{
    private readonly IAssetProvider _assetProvider;
    private readonly IInstantiator _instantiator;
    private readonly Vector3 _farAway = new Vector3(-999, 999, 0);

    public EntityViewFactory(IAssetProvider assetProvider, IInstantiator instantiator)
    {
        _assetProvider = assetProvider;
        _instantiator = instantiator;
    }
    
    public EntityBehaviour CreateViewForEntity(GameEntity entity)
    {
        var prefab = _assetProvider.LoadAsset<EntityBehaviour>(entity.viewPath.value);
        var view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
            prefab, _farAway, Quaternion.identity, null);
        view.SetEntity(entity);

        return view;
    }
    
    public EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity)
    {
        var view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
            entity.viewPrefab.value, _farAway, Quaternion.identity, null);
        view.SetEntity(entity);

        return view;
    }
}
}