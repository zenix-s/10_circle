using System.Collections.Generic;
using CircleGame.Core.Systems.Stats;

namespace CircleGame.Core.Systems.PassiveSpells;

public class PassiveSpell
{
	public PassiveSpell(
		PassiveSpellType type,
		string name,
		int level,
		BaseStat effect,
		List<float> effectValuesPerLevel,
		List<float> costPerLevel)
	{
		Type = type;
		Name = name;
		Level = level;
		Effect = effect;
		EffectValuesPerLevel = effectValuesPerLevel;
		CostPerLevel = costPerLevel;
	}

	public PassiveSpell(
		PassiveSpellType type,
		string name,
		BaseStat effect,
		List<float> effectValuesPerLevel,
		List<float> costPerLevel)
		: this(type, name, 0, effect, effectValuesPerLevel, costPerLevel)
	{
	}

	public PassiveSpellType Type { get; set; }
	public string Name { get; set; }
	public int Level { get; private set; }

	public BaseStat Effect { get; set; }
	public List<float> EffectValuesPerLevel { get; set; }
	// TODO: Aunque empiezo con esto de coste de mana, en un futuro tocara rectorizarlo para usar un sistema de costes
	public List<float> CostPerLevel { get; set; }

	public void LevelUp()
	{
		if (Level < EffectValuesPerLevel.Count)
		{
			Level++;
		}
	}

	public PassiveSpell Clone() => new(
		Type,
		Name,
		Level,
		Effect,
		[
			..EffectValuesPerLevel
		],
		[
			..CostPerLevel
		]);
}
