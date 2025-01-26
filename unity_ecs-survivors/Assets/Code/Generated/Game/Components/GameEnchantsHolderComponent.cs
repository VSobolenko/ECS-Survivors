//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherEnchantsHolder;

    public static Entitas.IMatcher<GameEntity> EnchantsHolder {
        get {
            if (_matcherEnchantsHolder == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EnchantsHolder);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEnchantsHolder = matcher;
            }

            return _matcherEnchantsHolder;
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

    public Code.Gameplay.Features.Enchants.EnchantsHolderComponent enchantsHolder { get { return (Code.Gameplay.Features.Enchants.EnchantsHolderComponent)GetComponent(GameComponentsLookup.EnchantsHolder); } }
    public Code.Gameplay.Features.Enchants.Behaviours.EnchantHolder EnchantsHolder { get { return enchantsHolder.Value; } }
    public bool hasEnchantsHolder { get { return HasComponent(GameComponentsLookup.EnchantsHolder); } }

    public GameEntity AddEnchantsHolder(Code.Gameplay.Features.Enchants.Behaviours.EnchantHolder newValue) {
        var index = GameComponentsLookup.EnchantsHolder;
        var component = (Code.Gameplay.Features.Enchants.EnchantsHolderComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Enchants.EnchantsHolderComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceEnchantsHolder(Code.Gameplay.Features.Enchants.Behaviours.EnchantHolder newValue) {
        var index = GameComponentsLookup.EnchantsHolder;
        var component = (Code.Gameplay.Features.Enchants.EnchantsHolderComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Enchants.EnchantsHolderComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveEnchantsHolder() {
        RemoveComponent(GameComponentsLookup.EnchantsHolder);
        return this;
    }
}
