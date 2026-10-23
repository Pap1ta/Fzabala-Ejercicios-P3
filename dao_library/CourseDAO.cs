using entity_library;

namespace dao_library;

public class CourseDAO
{
    public Course CreateCourse(Course course)
    {
        course.Id = MockDatabase.Courses.Count == 0 ? 1 : MockDatabase.Courses.Max(x => x.Id) + 1;
        MockDatabase.Courses.Add(course);
        return course;
    }

    public Course? ReadCourseById(long id)
    {
        return MockDatabase.Courses.FirstOrDefault(x => x.Id == id);
    }

    public bool UpdateCourse(Course course)
    {
        var index = MockDatabase.Courses.FindIndex(x => x.Id == course.Id);
        if (index == -1)
        {
            return false;
        }

        MockDatabase.Courses[index] = course;
        return true;
    }

    public bool DeleteCourseById(long id)
    {
        var course = ReadCourseById(id);
        if (course == null)
        {
            return false;
        }

        return MockDatabase.Courses.Remove(course);
    }

    public List<Course> GetAllCourses()
    {
        return MockDatabase.Courses.ToList();
    }
}
