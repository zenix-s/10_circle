using System;
using System.Collections.Generic;
using System.Linq;
using CircleGame;
using CircleGame.Core.Domain.PassiveSpells;

namespace CircleGame.Core.Systems.Stats;


public enum BaseStats
{
    ManaRegen
}

public class StatManager
{
    private GameManager _gameManager;
    
    private readonly Dictionary<BaseStats, float> _base = new()
    {
        [BaseStats.ManaRegen] = 0f,
    };

    public StatManager(GameManager manager)
    {
        _gameManager = manager; 
    }
    
    public float GetBase(BaseStats stat) => _base.GetValueOrDefault(stat, 0f);
    public void SetBase(BaseStats stat, float value) => _base[stat] = value;

    public float GetFinal(BaseStats stat)
    {
        float finalStat = 0;
        
        float baseStat = GetBase(stat);

        float passiveSpellModifier = _gameManager
            .PassiveSpellManager
            .PassiveSpells
            .Where(x => x.Value.Effect.Equals(stat))
            .Select(x => x.Value.EffectValuesPerLevel[x.Value.Level - 1])
            .Sum();
        
        finalStat = baseStat + passiveSpellModifier; 

        return finalStat;
    }
}
