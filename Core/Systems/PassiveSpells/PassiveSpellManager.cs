using System.Collections.Generic;
using System.Linq;
using CircleGame.Core.Systems.Stats;

namespace CircleGame.Core.Systems.PassiveSpells;

public enum PassiveSpellType
{
    ManaRegen
}

public class PassiveSpellManager : IStatModifierSource
{
    public Dictionary<PassiveSpellType, PassiveSpell> PassiveSpells { get; } =
        PassiveSpellsRegistry.PassiveSpells.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Clone());

    public IEnumerable<StatModifier> GetModifiers(BaseStat stat)
    {
        return PassiveSpells
            .Where(x => x.Value.Effect.Equals(stat) && x.Value.Level > 0)
            .Select(x => new StatModifier(x.Value.EffectValuesPerLevel[x.Value.Level - 1], ModifierType.Flat));
    }
}
