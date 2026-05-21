using System.Collections.Generic;
using CircleGame.Core.Systems.Stats;

namespace CircleGame.Core.Systems.PassiveSpells;

public class PassiveSpell
{
    public PassiveSpell(PassiveSpellType type, string name, int level, BaseStat effect, List<float> effectValuesPerLevel)
    {
        Type = type;
        Name = name;
        Level = level;
        Effect = effect;
        EffectValuesPerLevel = effectValuesPerLevel;
    }

    public PassiveSpell(PassiveSpellType type, string name, BaseStat effect, List<float> effectValuesPerLevel)
        : this(type, name, 0, effect, effectValuesPerLevel)
    {
    }

    public PassiveSpellType Type { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }

    public BaseStat Effect { get; set; }
    public List<float> EffectValuesPerLevel { get; set; }

    public void LevelUp()
    {
        if (Level < EffectValuesPerLevel.Count)
        {
            Level++;
        }
    }

    public PassiveSpell Clone() =>
        new PassiveSpell(Type, Name, Level, Effect, new List<float>(EffectValuesPerLevel));
}
