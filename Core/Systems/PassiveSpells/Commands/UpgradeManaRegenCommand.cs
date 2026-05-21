using CircleGame.Core.Commands;
using CircleGame.Core.Systems.PassiveSpells;

namespace CircleGame.Core.Systems.PassiveSpells.Commands;

public class UpgradeManaRegenCommand : IGameCommand
{
    public bool CanExecute(GameManager gameManager)
    {
        var spell = gameManager.PassiveSpellManager.PassiveSpells[PassiveSpellType.ManaRegen];
        return spell.Level < spell.EffectValuesPerLevel.Count;
    }

    public void Execute(GameManager gameManager)
    {
        gameManager.PassiveSpellManager.PassiveSpells[PassiveSpellType.ManaRegen].LevelUp();
    }
}
