using entity_library;

namespace dao_library;

public class TeamDAO
{
    public Team CreateTeam(Team team)
    {
        team.Id = MockDatabase.Teams.Count == 0 ? 1 : MockDatabase.Teams.Max(x => x.Id) + 1;
        MockDatabase.Teams.Add(team);
        return team;
    }

    public Team? ReadTeamById(long id)
    {
        return MockDatabase.Teams.FirstOrDefault(x => x.Id == id);
    }

    public bool UpdateTeam(Team team)
    {
        var index = MockDatabase.Teams.FindIndex(x => x.Id == team.Id);
        if (index == -1)
        {
            return false;
        }

        MockDatabase.Teams[index] = team;
        return true;
    }

    public bool DeleteTeamById(long id)
    {
        var team = ReadTeamById(id);
        if (team == null)
        {
            return false;
        }

        return MockDatabase.Teams.Remove(team);
    }

    public List<Team> GetAllTeams()
    {
        return MockDatabase.Teams.ToList();
    }
}
