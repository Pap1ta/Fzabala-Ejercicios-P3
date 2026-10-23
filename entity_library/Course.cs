using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_library;

public class Course
{
    public string Name { get; set; } = string.Empty;
    public List<Student> Students { get; set; } = new List<Student>();
    public List<Activity> Activities { get; set; } = new List<Activity>();
    public long Id { get; set; }
}
