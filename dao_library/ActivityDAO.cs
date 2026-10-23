using entity_library;

namespace dao_library;

public class ActivityDAO
{
    public Activity CreateActivity(Activity activity)
    {
        activity.Id = MockDatabase.Activities.Count == 0 ? 1 : MockDatabase.Activities.Max(x => x.Id) + 1;
        MockDatabase.Activities.Add(activity);
        return activity;
    }

    public Activity? ReadActivityById(long id)
    {
        return MockDatabase.Activities.FirstOrDefault(x => x.Id == id);
    }

    public bool UpdateActivity(Activity activity)
    {
        var index = MockDatabase.Activities.FindIndex(x => x.Id == activity.Id);
        if (index == -1)
        {
            return false;
        }

        MockDatabase.Activities[index] = activity;
        return true;
    }

    public bool DeleteActivityById(long id)
    {
        var activity = ReadActivityById(id);
        if (activity == null)
        {
            return false;
        }

        return MockDatabase.Activities.Remove(activity);
    }

    public List<Activity> GetAllActivities()
    {
        return MockDatabase.Activities.ToList();
    }
}
