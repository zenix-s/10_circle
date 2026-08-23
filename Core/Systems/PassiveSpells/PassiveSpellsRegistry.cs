using System.Collections.Generic;
using CircleGame.Core.Systems.Stats;

namespace CircleGame.Core.Systems.PassiveSpells;

public static class PassiveSpellsRegistry
{
	public static Dictionary<PassiveSpellType, PassiveSpell> PassiveSpells { get; } = new()
	{
		{
			PassiveSpellType.ManaRegen,
			new PassiveSpell(
				type: PassiveSpellType.ManaRegen,
				name: "Mana Regen",
				effect: BaseStat.ManaRegen,
				effectValuesPerLevel: [1f, 2.5f, 5f],
				costPerLevel: [0, 10, 50]
			)
		}
	};
}
