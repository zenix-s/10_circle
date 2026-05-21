using System.Linq;
using CircleGame.Core.Domain.PassiveSpells;
using CircleGame.Core.Systems.Stats;

namespace CircleGame.Core.Commands;

public class UpgradeManaRegenCommand : IGameCommand
{
	public bool CanExecute(GameManager gameManager)
	{
		return true;
	}

	public void Execute(GameManager gameManager)
	{
		if (!gameManager.PassiveSpellManager.PassiveSpells.ContainsKey(PassiveSpellType.ManaRegen))
			gameManager.PassiveSpellManager.PassiveSpells.Add(
				PassiveSpellType.ManaRegen,
				PassiveSpellsRegistry.PassiveSpells[PassiveSpellType.ManaRegen]
			);
			
		gameManager.PassiveSpellManager.PassiveSpells[PassiveSpellType.ManaRegen].LevelUp();
	}
}
