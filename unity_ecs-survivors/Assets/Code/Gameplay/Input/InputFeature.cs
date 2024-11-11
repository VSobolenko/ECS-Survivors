using Code.Infrastructure.Systems;

namespace Code.Gameplay.Input.Service.Systems
{
public class InputFeature : Feature
{
    public InputFeature(ISystemFactory systems)
    {
        Add(systems.Create<InitializeInputSystem>());
        Add(systems.Create<EmitInputSystem>());
    }
}
}