namespace CircleGame.Core.Systems.Stats;

public enum ModifierType
{
    Flat,
    Multiplier
}

public enum BaseStat
{
    ManaRegen
}

public readonly struct StatModifier(float value, ModifierType type)
{
    public float Value { get; } = value;
    public ModifierType Type { get; } = type;
}
