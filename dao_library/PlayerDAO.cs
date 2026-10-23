using entity_library;

namespace dao_library;

public class PlayerDAO
{
    public Player CreatePlayer(Player player)
    {
        player.Id = MockDatabase.Players.Count == 0 ? 1 : MockDatabase.Players.Max(x => x.Id) + 1;
        MockDatabase.Players.Add(player);
        return player;
    }

    public Player? ReadPlayerById(long id)
    {
        return MockDatabase.Players.FirstOrDefault(x => x.Id == id);
    }

    public bool UpdatePlayer(Player player)
    {
        var index = MockDatabase.Players.FindIndex(x => x.Id == player.Id);
        if (index == -1)
        {
            return false;
        }

        MockDatabase.Players[index] = player;
        return true;
    }

    public bool DeletePlayerById(long id)
    {
        var player = ReadPlayerById(id);
        if (player == null)
        {
            return false;
        }

        return MockDatabase.Players.Remove(player);
    }

    public List<Player> GetAllPlayers()
    {
        return MockDatabase.Players.ToList();
    }
}
