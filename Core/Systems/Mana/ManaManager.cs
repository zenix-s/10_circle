using CircleGame.Core.Systems.Stats;
using Godot;

namespace CircleGame.Core.Systems.Mana;

public partial class ManaManager : Node
{
	public static ManaManager Instance { get; private set; }

	public float Mana { get; set; } = 0f;
    public bool IsCultivating { get; set; } = false;

	public int Circle { get; set; } = 0;
    public int Star { get; set; } = 0;

	public override void _EnterTree()
	{
		Instance = this;
	}

	public override void _Ready()
	{
		TickManager.Instance.Tick += OnTick;
	}

	private void OnTick()
	{
		float manaRegen = StatManager.Instance.GetFinal(BaseStat.ManaRegen);
		
		Mana += manaRegen;
		if (IsCultivating) Mana += manaRegen;
	}
}
