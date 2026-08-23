namespace CircleGame.Core.Systems.ActiveSpells;

public class ActiveSpell
{
    public ActiveSpell(ActiveSpellType type, string name, float baseDamage, int cooldownTicks)
    {
        Type = type;
        Name = name;
        BaseDamage = baseDamage;
        CooldownTicks = cooldownTicks;
    }

    public ActiveSpellType Type { get; }
    public string Name { get; }
    public float BaseDamage { get; }
    public int CooldownTicks { get; }
}
