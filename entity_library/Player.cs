using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_library;

public class Player : Person
{
    public int Numero { get; set; }
    public List<Team> Teams { get; set; } = new List<Team>();
}