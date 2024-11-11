//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSpeed;

    public static Entitas.IMatcher<GameEntity> Speed {
        get {
            if (_matcherSpeed == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Speed);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSpeed = matcher;
            }

            return _matcherSpeed;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Code.Gameplay.Features.Movement.MovementComponents.Speed speed { get { return (Code.Gameplay.Features.Movement.MovementComponents.Speed)GetComponent(GameComponentsLookup.Speed); } }
    public bool hasSpeed { get { return HasComponent(GameComponentsLookup.Speed); } }

    public GameEntity AddSpeed(float newValue) {
        var index = GameComponentsLookup.Speed;
        var component = (Code.Gameplay.Features.Movement.MovementComponents.Speed)CreateComponent(index, typeof(Code.Gameplay.Features.Movement.MovementComponents.Speed));
        component.value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceSpeed(float newValue) {
        var index = GameComponentsLookup.Speed;
        var component = (Code.Gameplay.Features.Movement.MovementComponents.Speed)CreateComponent(index, typeof(Code.Gameplay.Features.Movement.MovementComponents.Speed));
        component.value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveSpeed() {
        RemoveComponent(GameComponentsLookup.Speed);
        return this;
    }
}
