using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_library;

public class Activity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TypeActivity Type { get; set; }
    public DateTime Date { get; set; }
    public long Id { get; set; }
}
