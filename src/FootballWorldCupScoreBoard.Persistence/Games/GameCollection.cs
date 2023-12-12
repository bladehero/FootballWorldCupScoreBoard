using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace FootballWorldCupScoreBoard.Persistence.Games;

[ExcludeFromCodeCoverage]
public class GameCollection : IList<GameModel>
{
    private readonly List<GameModel> _games = new();

    public int Count => _games.Count;

    public bool IsReadOnly => ((IList)_games).IsReadOnly;

    public GameModel this[int index]
    {
        get => _games[index];
        set => _games[index] = value;
    }

    public IEnumerator<GameModel> GetEnumerator() => _games.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _games.GetEnumerator();

    public void Add(GameModel item) => _games.Add(item);

    public void Clear() => _games.Clear();

    public bool Contains(GameModel item) => _games.Contains(item);

    public void CopyTo(GameModel[] array, int arrayIndex) => _games.CopyTo(array, arrayIndex);

    public bool Remove(GameModel item) => _games.Remove(item);

    public int IndexOf(GameModel item) => _games.IndexOf(item);

    public void Insert(int index, GameModel item) => _games.Insert(index, item);

    public void RemoveAt(int index) => _games.RemoveAt(index);
}
