namespace CircleGame.Core.Queries;

public interface IGameQuery<out T>
{
    T Get(GameManager gameManager);
}