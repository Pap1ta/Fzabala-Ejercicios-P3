using entity_library;

namespace dao_library;

public class StudentDAO
{
    public Student CreateStudent(Student student)
    {
        student.Id = MockDatabase.Students.Count == 0 ? 1 : MockDatabase.Students.Max(x => x.Id) + 1;
        MockDatabase.Students.Add(student);
        return student;
    }

    public Student? ReadStudentById(long id)
    {
        return MockDatabase.Students.FirstOrDefault(x => x.Id == id);
    }

    public bool UpdateStudent(Student student)
    {
        var index = MockDatabase.Students.FindIndex(x => x.Id == student.Id);
        if (index == -1)
        {
            return false;
        }

        MockDatabase.Students[index] = student;
        return true;
    }

    public bool DeleteStudentById(long id)
    {
        var student = ReadStudentById(id);
        if (student == null)
        {
            return false;
        }

        return MockDatabase.Students.Remove(student);
    }

    public List<Student> GetAllStudents()
    {
        return MockDatabase.Students.ToList();
    }
}
