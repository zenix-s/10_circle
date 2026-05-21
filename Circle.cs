using Godot;
using CircleGame.Core;

namespace CircleGame;

public partial class Circle : Node
{
    public static Circle Instance { get; private set; }

    public GameManager GameManager { get; private set; } = new();

    public override void _Ready()
    {
        Instance = this;
        GameManager ??= new GameManager();
    }

    public override void _Process(double delta)
    {
        GameManager.ProcessTime(delta);
    }
}
