//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCurrentHP;

    public static Entitas.IMatcher<GameEntity> CurrentHP {
        get {
            if (_matcherCurrentHP == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CurrentHP);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCurrentHP = matcher;
            }

            return _matcherCurrentHP;
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

    public Code.Gameplay.Features.Lifetime.CurrentHP currentHP { get { return (Code.Gameplay.Features.Lifetime.CurrentHP)GetComponent(GameComponentsLookup.CurrentHP); } }
    public bool hasCurrentHP { get { return HasComponent(GameComponentsLookup.CurrentHP); } }

    public GameEntity AddCurrentHP(float newValue) {
        var index = GameComponentsLookup.CurrentHP;
        var component = (Code.Gameplay.Features.Lifetime.CurrentHP)CreateComponent(index, typeof(Code.Gameplay.Features.Lifetime.CurrentHP));
        component.value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceCurrentHP(float newValue) {
        var index = GameComponentsLookup.CurrentHP;
        var component = (Code.Gameplay.Features.Lifetime.CurrentHP)CreateComponent(index, typeof(Code.Gameplay.Features.Lifetime.CurrentHP));
        component.value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveCurrentHP() {
        RemoveComponent(GameComponentsLookup.CurrentHP);
        return this;
    }
}
