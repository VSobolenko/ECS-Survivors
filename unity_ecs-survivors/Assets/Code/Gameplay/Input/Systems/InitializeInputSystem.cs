using System;
using Code.Common.Entity;
using Entitas;

namespace Code.Gameplay.Input.Service.Systems
{
public class InitializeInputSystem : IInitializeSystem
{
    public void Initialize()
    {
        CreateEntity.Empty().isInput = true;
    }
}
}