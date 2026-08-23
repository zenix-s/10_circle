using System.Collections.Generic;

namespace CircleGame.Core.Systems.ActiveSpells;

public enum ActiveSpellType
{
    Damage
}

public static class ActiveSpellsRegistry
{
    public static Dictionary<ActiveSpellType, ActiveSpell> Spells { get; } = new()
    {
        [ActiveSpellType.Damage] = new ActiveSpell(
            type: ActiveSpellType.Damage,
            name: "Magic Bolt",
            baseDamage: 1f,
            cooldownTicks: 1
        )
    };
}
