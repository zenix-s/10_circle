namespace CircleGame.Core.Commands;

public interface IGameCommand
{
        bool CanExecute(GameManager gameManager);
        void Execute(GameManager gameManager);
}