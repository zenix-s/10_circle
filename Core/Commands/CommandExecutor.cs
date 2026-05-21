namespace CircleGame.Core.Commands;

public static class CommandExecutor
{
    public static void TryExecuteCommand(this IGameCommand command, GameManager gameManager)
    {
        if (command.CanExecute(gameManager))
        {
            command.Execute(gameManager);
        }
    }
}