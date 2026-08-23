using System.Collections.Generic;
using System.Linq;
using CircleGame.Core.Systems.Mana;
using CircleGame.Core.Systems.Stats;
using Godot;

namespace CircleGame.Core.Systems.PassiveSpells;

public enum PassiveSpellType
{
	ManaRegen
}

public partial class PassiveSpellManager : Node, IStatModifierSource
{
	public static PassiveSpellManager Instance { get; private set; }

	public Dictionary<PassiveSpellType, PassiveSpell> PassiveSpells { get; } = new();

	public override void _EnterTree()
	{
		Instance = this;
	}

	public override void _Ready()
	{
		PassiveSpellsRegistry.PassiveSpells.ToList().ForEach(kvp => PassiveSpells[kvp.Key] = kvp.Value.Clone());
		StatManager.Instance.RegisterSource(this);
	}

	public void UpgradeSpell(PassiveSpellType type)
	{
		PassiveSpell spell = PassiveSpells[type];
		if (spell.Level >= spell.EffectValuesPerLevel.Count) return;
		float cost = spell.CostPerLevel[spell.Level];
		if (ManaManager.Instance.Mana < cost) return;
		ManaManager.Instance.Mana -= cost;
		spell.LevelUp();
	}

	public IEnumerable<StatModifier> GetModifiers(BaseStat stat)
	{
		return PassiveSpells
			.Where(x => x.Value.Effect.Equals(stat) && x.Value.Level > 0)
			.Select(x => new StatModifier(x.Value.EffectValuesPerLevel[x.Value.Level - 1], ModifierType.Flat));
	}
}
