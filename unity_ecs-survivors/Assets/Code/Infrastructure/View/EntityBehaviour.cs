﻿using Code.Gameplay.Common.Collisions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View
{
public class EntityBehaviour : MonoBehaviour, IEntityView
{
    private GameEntity _entity;
    private ICollisionRegistry _collisionRegistry;
    public GameEntity Entity => _entity;

    [Inject]
    public void Construct(ICollisionRegistry collisionRegistry)
    {
        _collisionRegistry = collisionRegistry;
    }
    
    public void SetEntity(GameEntity entity)
    {
        _entity = entity;
        _entity.AddView(this);
        _entity.Retain(this);

        foreach (var registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
            registrar.RegisterComponents();

        foreach (var collider2d in GetComponentsInChildren<Collider2D>(true))
            _collisionRegistry.Register(collider2d.GetInstanceID(), _entity);
    }

    public void ReleaseEntity()
    {
        foreach (var registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
            registrar.UnRegisterComponents();

        foreach (var collider2d in GetComponentsInChildren<Collider2D>(true))
            _collisionRegistry.Unregister(collider2d.GetInstanceID());
        
        _entity.Release(this);
        _entity = null;
    }
}
}