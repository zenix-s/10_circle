using System.Collections.Generic;

namespace CircleGame.Core.Domain.PassiveSpells;

public enum PassiveSpellType
{
    ManaRegen
}

/// <summary>
/// Aqui se manejan los hechizos pasivos y sus niveles
/// </summary>
public class PassiveSpellManager
{
    public Dictionary<PassiveSpellType, PassiveSpell> PassiveSpells { get; set; }
}