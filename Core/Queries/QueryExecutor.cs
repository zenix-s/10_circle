using CircleGame.Core.Queries;

namespace CircleGame.Core.Commands;

public static class QueryExecutor
{
    public static T TryExecuteQuery<T>(this IGameQuery<T> query, GameManager gameManager)
    {
        return query.Get(gameManager);
    }
}