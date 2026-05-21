namespace CircleGame.Core.Queries;

public class GetManaQuery : IGameQuery<float>
{
    public float Get(GameManager gameManager)
    {
        return gameManager.Mana;
    }
}