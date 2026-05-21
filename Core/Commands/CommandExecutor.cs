namespace CircleGame.Core.Commands;

public class CommandExecutor(GameManager gameManager)
{
    public void TryExecute(IGameCommand command)
    {
        if (command.CanExecute(gameManager))
        {
            command.Execute(gameManager);
        }
    }
}
