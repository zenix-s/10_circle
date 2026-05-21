using System.Collections.Generic;

namespace CircleGame.Core.Systems.Stats;

public interface IStatModifierSource
{
    IEnumerable<StatModifier> GetModifiers(BaseStat stat);
}
