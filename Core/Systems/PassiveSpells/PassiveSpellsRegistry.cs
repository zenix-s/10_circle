using System.Collections.Generic;
using CircleGame.Core.Systems.Stats;

namespace CircleGame.Core.Systems.PassiveSpells;

public static class PassiveSpellsRegistry
{
    public static Dictionary<PassiveSpellType, PassiveSpell> PassiveSpells { get; set; } = new()
    {
        {
            PassiveSpellType.ManaRegen,
            new PassiveSpell(
                type: PassiveSpellType.ManaRegen,
                name: "Mana Regen",
                effect: BaseStat.ManaRegen,
                effectValuesPerLevel: [0.5f, 1f, 1.5f]
            )
        }
    };
}
