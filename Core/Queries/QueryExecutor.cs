namespace CircleGame.Core.Queries;

public class QueryExecutor(GameManager gameManager)
{
    public T Execute<T>(IGameQuery<T> query)
    {
        return query.Get(gameManager);
    }
}
