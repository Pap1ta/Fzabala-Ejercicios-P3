using entity_library;

namespace dao_library;

public class TrainerDAO
{
    public Trainer CreateTrainer(Trainer trainer)
    {
        trainer.Id = MockDatabase.Trainers.Count == 0 ? 1 : MockDatabase.Trainers.Max(x => x.Id) + 1;
        MockDatabase.Trainers.Add(trainer);
        return trainer;
    }

    public Trainer? ReadTrainerById(long id)
    {
        return MockDatabase.Trainers.FirstOrDefault(x => x.Id == id);
    }

    public bool UpdateTrainer(Trainer trainer)
    {
        var index = MockDatabase.Trainers.FindIndex(x => x.Id == trainer.Id);
        if (index == -1)
        {
            return false;
        }

        MockDatabase.Trainers[index] = trainer;
        return true;
    }

    public bool DeleteTrainerById(long id)
    {
        var trainer = ReadTrainerById(id);
        if (trainer == null)
        {
            return false;
        }

        return MockDatabase.Trainers.Remove(trainer);
    }

    public List<Trainer> GetAllTrainers()
    {
        return MockDatabase.Trainers.ToList();
    }
}
