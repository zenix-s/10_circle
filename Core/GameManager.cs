using CircleGame.Core.Commands;
using CircleGame.Core.Queries;
using CircleGame.Core.Systems.PassiveSpells;
using CircleGame.Core.Systems.Stats;

namespace CircleGame.Core;

public class GameManager
{
    private readonly TickManager _tickManager = new();

    public readonly PassiveSpellManager PassiveSpellManager = new();

    public StatManager Stats { get; }
    public CommandExecutor Commands { get; }
    public QueryExecutor Queries { get; }

    public float Mana { get; set; } = 0f;

    public GameManager()
    {
        Stats = new StatManager();
        Stats.RegisterSource(PassiveSpellManager);
        Commands = new CommandExecutor(this);
        Queries = new QueryExecutor(this);
        _tickManager.Tick += OnTick;
    }

    public void ProcessTime(double delta)
    {
        _tickManager.ProcessTime(delta);
    }

    private void OnTick()
    {
        Mana += Stats.GetFinal(BaseStat.ManaRegen);
    }
}
