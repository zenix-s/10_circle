using CircleGame.Core;
using CircleGame.Core.Queries;

namespace CircleGame.Core.Systems.PassiveSpells.Queries;

public class GetManaQuery : IGameQuery<float>
{
    public float Get(GameManager gameManager)
    {
        return gameManager.Mana;
    }
}
