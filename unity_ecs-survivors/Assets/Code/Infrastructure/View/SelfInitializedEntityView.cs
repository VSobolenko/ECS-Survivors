using System;
using Code.Common.Entity;
using Code.Infrastructure.Identifiers;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View
{
public class SelfInitializedEntityView : MonoBehaviour
{
    public EntityBehaviour entityBehaviour;
    private IIdentifierService _eIdentifierService;

    [Inject]
    public void Construct(IIdentifierService eIdentifierService)
    {
        _eIdentifierService = eIdentifierService;
    }
    
    private void Awake()
    {
        var entity = CreateEntity.Empty().AddId(_eIdentifierService.Next());
        entityBehaviour.SetEntity(entity);
    }
}
}