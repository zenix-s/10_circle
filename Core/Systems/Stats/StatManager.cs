using System.Collections.Generic;
using System.Linq;
using Godot;

namespace CircleGame.Core.Systems.Stats;

public partial class StatManager : Node
{
	public static StatManager Instance { get; private set; }

	private readonly List<IStatModifierSource> _sources = new();

	private readonly Dictionary<BaseStat, float> _base = new()
	{
		[BaseStat.ManaRegen] = 1f,
	};

	public override void _EnterTree()
	{
		Instance = this;
	}

	public void RegisterSource(IStatModifierSource source) => _sources.Add(source);

	public float GetBase(BaseStat stat) => _base.GetValueOrDefault(stat, 0f);
	public void SetBase(BaseStat stat, float value) => _base[stat] = value;

	public float GetFinal(BaseStat stat)
	{
		var modifiers = _sources.SelectMany(s => s.GetModifiers(stat)).ToList();

		float flats = modifiers
			.Where(m => m.Type == ModifierType.Flat)
			.Sum(m => m.Value);

		float multiplier = modifiers
			.Where(m => m.Type == ModifierType.Multiplier)
			.Aggregate(1f, (acc, m) => acc * m.Value);

		return (GetBase(stat) + flats) * multiplier;
	}
}
