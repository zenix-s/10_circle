using System.Collections.Generic;
using CircleGame.Core.Domain.PassiveSpells;
using CircleGame.Core.Systems.Stats;

namespace CircleGame.Core;

public class GameManager
{
	private readonly TickManager _tickManager = new();
	
	public  readonly PassiveSpellManager PassiveSpellManager = new();

	public StatManager Stats { get; }

	public float Mana { get; set; } = 0f;
	
	public GameManager()
	{
		Stats = new StatManager(this);
		_tickManager.Tick += OnTick;
	}

	public void ProcessTime(double delta)
	{
		_tickManager.ProcessTime(delta);
	}

	private void OnTick()
	{
		Mana += Stats.GetFinal(BaseStats.ManaRegen);
	}
}
