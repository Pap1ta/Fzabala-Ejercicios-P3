using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_library;

public class Student : Person
{
    public string File { get; set; } = string.Empty;
    public List<Course> Courses { get; set; } = new List<Course>();
}