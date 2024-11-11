using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Service.Systems
{
public class EmitInputSystem : IExecuteSystem
{
    private readonly IInputService _inputService;
    private readonly IGroup<GameEntity> _input;

    public EmitInputSystem(GameContext gameContext, IInputService inputService)
    {
        _inputService = inputService;
        _input = gameContext.GetGroup(GameMatcher.Input);
    }    
    
    public void Execute()
    {
        foreach (var input in _input)
        {
            if (_inputService.HasAxisInput())
                input.ReplaceAxisInput(new Vector2(_inputService.GetHorizontalAxis(), _inputService.GetVerticalAxis()));
            else if (input.hasAxisInput)
                input.RemoveAxisInput();
        }
    }
}
}