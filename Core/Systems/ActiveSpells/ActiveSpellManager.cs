using System.Collections.Generic;
using CircleGame.Core.Systems.Tower;
using Godot;

namespace CircleGame.Core.Systems.ActiveSpells;

public partial class ActiveSpellManager : Node
{
    public static ActiveSpellManager Instance { get; private set; }

    public List<ActiveSpellSlot> Slots { get; } = new();

    public override void _EnterTree()
    {
        Instance = this;
    }

    public override void _Ready()
    {
        Slots.Add(new ActiveSpellSlot());
        // TODO: Quitar cuando exista UI de asignacion de magias
        Slots[0].Spell = ActiveSpellsRegistry.Spells[ActiveSpellType.Damage];

        TickManager.Instance.Tick += OnTick;
    }

    private void OnTick()
    {
        foreach (ActiveSpellSlot slot in Slots)
        {
            ActiveSpell fired = slot.OnTick();
            if (fired != null)
                // TODO: El efecto deberia definirse en la magia, no aqui
                TowerManager.Instance.DealDamage(fired.BaseDamage);
        }
    }
}
