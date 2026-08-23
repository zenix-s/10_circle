namespace CircleGame.Core.Systems.ActiveSpells;

public class ActiveSpellSlot
{
    public ActiveSpell? Spell { get; set; }
    private int _ticksUntilFire = 0;

    public ActiveSpell? OnTick()
    {
        if (Spell == null) return null;
        if (_ticksUntilFire > 0)
        {
            _ticksUntilFire--;
            return null;
        }
        _ticksUntilFire = Spell.CooldownTicks - 1;
        return Spell;
    }
}
